import pandas as pd
from bs4 import BeautifulSoup
import re
from nltk.corpus import stopwords
from sklearn.feature_extraction.text import CountVectorizer
import numpy as np
from sklearn.ensemble import RandomForestClassifier
import matplotlib.pyplot as plt
import matplotlib
matplotlib.style.use('ggplot')

train = pd.read_csv("C:/Project/train.tsv",encoding = "latin1",  header=0,error_bad_lines=False,  \
                    delimiter=",", quoting=3)
print(train.shape)

test = pd.read_csv("C:/Project/testTextss.tsv", encoding = "latin1",  header=0, delimiter=",", error_bad_lines=False, \
                 quoting=3)
print(test.shape)

def texts_to_words( raw_texts ):

    texts_text = BeautifulSoup(raw_texts).get_text()
    letters_only = re.sub("[^a-zA-Z]", " ", texts_text)
    words = letters_only.lower().split()
    stops = set(stopwords.words("english"))
    meaningful_words = [w for w in words if not w in stops]
    return( " ".join( meaningful_words ))

clean_text = texts_to_words(train["SentimentText"][0])
print(clean_text)

num_texts = train["SentimentText"].size

print("Cleaning and parsing the training set texts...\n")
clean_train_texts = []
for i in range( 0, num_texts ):
    if ((i + 1) % 1000 == 0):
        print("Text %d of %d\n" % (i + 1, num_texts))
    clean_train_texts.append( texts_to_words(train["SentimentText"][i] ))

vectorizer = CountVectorizer(analyzer = "word",   \
                             tokenizer = None,    \
                             preprocessor = None, \
                             stop_words = None,   \
                             max_features = 5000)

train_data_features = vectorizer.fit_transform(clean_train_texts)
train_data_features = train_data_features.toarray()

vocab = vectorizer.get_feature_names()
print(vocab)

dist = np.sum(train_data_features, axis=0)
for tag, count in zip(vocab, dist):
    print(count, tag)

print("Training the random forest")

forest = RandomForestClassifier(n_estimators=100)
forest = forest.fit(train_data_features, train["Sentiment"])
num_texts = len(test["text_title_text"])
clean_test_texts = []

print("Cleaning and parsing the test set texts...\n")
for i in range(0,num_texts):
    if( (i+1) % 1000 == 0 ):
        print("Texts %d of %d\n" % (i+1, num_texts))
    clean_texts = texts_to_words(test["text_title_text"][i])
    clean_test_texts.append(clean_texts)


test_data_features = vectorizer.transform(clean_test_texts)
test_data_features = test_data_features.toarray()

result = forest.predict(test_data_features)

output = pd.DataFrame(data={"id":test["published_date"], "sentiment":result})

output.to_csv("C:/Project/Bag_of_Words_model.csv", index=False, quoting=3)

data = pd.read_csv("C:/Project/Bag_of_Words_model.csv", encoding = "utf-8",  header=0, delimiter=",", parse_dates=['id'])
print(data.shape)

data.plot(x='id', y='sentiment', rot=0, figsize=(14, 10), grid=True, marker='o')
plt.show()
