import pandas as pd
from gensim.models import word2vec
from bs4 import BeautifulSoup
import re
from nltk.corpus import stopwords
from sklearn.preprocessing import Imputer
from sklearn.cluster import KMeans
from sklearn.preprocessing import StandardScaler
from sklearn.pipeline import Pipeline
from sklearn.ensemble import RandomForestClassifier
import time
import logging
import numpy as np
import nltk.data
nltk.download()

train = pd.read_csv("C:/Project/train.tsv",encoding = "latin1",  header=0,error_bad_lines=False,  \
                    delimiter=",", quoting=3)
print(train.shape)

test = pd.read_csv("C:/Project/testTextss.tsv", encoding = "latin1",  header=0, delimiter=",", error_bad_lines=False, \
                 quoting=3)
print(test.shape)
train

print (("Read %d labeled train texts, %d labeled test texts\n") % (train["SentimentText"].size, test["text_title_text"].size ))

def texts_to_wordlist( text, remove_stopwords=False ):
    text = BeautifulSoup(text).get_text()
    text = re.sub("[^a-zA-Z]"," ", text)
    words = text.lower().split()
    if remove_stopwords:
        stops = set(stopwords.words("english"))
        words = [w for w in words if not w in stops]

    return(words)

tokenizer = nltk.data.load('tokenizers/punkt/english.pickle')

def text_to_sentences( text, tokenizer, remove_stopwords=False ):
    raw_sentences = tokenizer.tokenize(text.strip())
    sentences = []
    for raw_sentence in raw_sentences:
        if len(raw_sentence) > 0:
            sentences.append( texts_to_wordlist( raw_sentence, \
            remove_stopwords ))
    return sentences



sentences = []

print ("Parsing sentences from training set")
for text in train["SentimentText"]:
    sentences += text_to_sentences(text, tokenizer)

logging.basicConfig(format='%(asctime)s : %(levelname)s : %(message)s',\
    level=logging.INFO)

num_features = 300
min_word_count = 40
num_workers = 4
context = 10
downsampling = 1e-3

print ("Training model...")
model = word2vec.Word2Vec(sentences, workers=num_workers, \
            size=num_features, min_count = min_word_count, \
            window = context, sample = downsampling, seed=1)

model.init_sims(replace=True)
model_name = "300features_40minwords_10context"
model.save(model_name)

def makeFeatureVec(words, model, num_features):
    featureVec = np.zeros((num_features,),dtype="float32")
    nwords = 0.
    index2word_set = set(model.wv.index2word)
    for word in words:
        if word in index2word_set:
            nwords = nwords + 1.
            featureVec = np.add(featureVec,model[word])
    featureVec = np.divide(featureVec,nwords)
    return featureVec


def getAvgFeatureVecs(texts, model, num_features):
    counter = 0.
    textFeatureVecs = np.zeros((len(texts), num_features), dtype="float32")
    for text in texts:
        if counter % 1000. == 0.:
            print ("text %d of %d" % (counter, len(texts)))
        textFeatureVecs[int(counter)] = makeFeatureVec(text, model, \
                                                         num_features)
        counter = counter + 1.
    return textFeatureVecs


print("Creating average feature vecs for training texts")
clean_train_texts = []
for text in train["SentimentText"]:
    clean_train_texts.append( texts_to_wordlist( text, \
        remove_stopwords=True ))


trainDataVecs = getAvgFeatureVecs( clean_train_texts, model, num_features )
trainDataVecs = Imputer ().fit_transform (trainDataVecs)

print ("Creating average feature vecs for test texts")
clean_test_texts = []
for text in test["text_title_text"]:
    clean_test_texts.append( texts_to_wordlist( text, \
        remove_stopwords=True ))

testDataVecs = getAvgFeatureVecs( clean_test_texts, model, num_features )
testDataVecs = Imputer ().fit_transform (testDataVecs )
forest = Pipeline([("scale", StandardScaler()),
                  ("forest", RandomForestClassifier(n_estimators=100))])
print ("Fitting a random forest to labeled training data...")
forest = forest.fit( trainDataVecs, train["Sentiment"] )

result = forest.predict( testDataVecs )

output = pd.DataFrame(data={"id":test["published_date"], "sentiment":result})
output.to_csv("C:/Project/Word2Vec_AverageVectors.csv", index=False, quoting=3)


start = time.time()

word_vectors = model.wv.syn0
num_clusters = int(word_vectors.shape[0] / 5)
kmeans_clustering = KMeans( n_clusters = num_clusters )
idx = kmeans_clustering.fit_predict( word_vectors )

end = time.time()
elapsed = end - start
print ("Time taken for K Means clustering: ", elapsed, "seconds.")
word_centroid_map = dict(zip( model.wv.index2word, idx ))

for cluster in range(0,10):
    print ("\nCluster %d" % cluster)
    words = []
    word_map_value = list(word_centroid_map.values())
    word_map_keys = list(word_centroid_map.keys())
    for i in range(0, len(word_centroid_map.values())):
        if (word_map_value[i] == cluster):
            words.append(word_map_keys[i])
    print(words)

def create_bag_of_centroids( wordlist, word_centroid_map ):
    num_centroids = max( word_centroid_map.values() ) + 1
    bag_of_centroids = np.zeros( num_centroids, dtype="float32" )
    for word in wordlist:
        if word in word_centroid_map:
            index = word_centroid_map[word]
            bag_of_centroids[index] += 1
    return bag_of_centroids

train_centroids = np.zeros( (train["SentimentText"].size, num_clusters), \
    dtype="float32" )

counter = 0
for text in clean_train_texts:
    train_centroids[counter] = create_bag_of_centroids( text, \
        word_centroid_map )
    counter += 1

test_centroids = np.zeros(( test["text_title_text"].size, num_clusters), \
dtype="float32" )

counter = 0
for text in clean_test_texts:
    test_centroids[counter] = create_bag_of_centroids( text, \
        word_centroid_map )
    counter += 1

forest = RandomForestClassifier(n_estimators = 100)

print("Fitting a random forest to labeled training data…")
forest = forest.fit(train_centroids,train["Sentiment"])
result = forest.predict(test_centroids)

output = pd.DataFrame(data={"id":test["published_date"], "sentiment":result})
output.to_csv( "C:/Project/BagOfCentroids.csv", index=False, quoting=3 )

