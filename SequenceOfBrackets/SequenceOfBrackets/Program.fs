  module SequenceOfBrackets

  let checkBraсkets myString =
      let rec helper myString stack =
          match (myString, stack) with
          | (('(' :: st), stack) -> helper st ('(' :: stack)
          | (('[' :: st), stack) -> helper st ('[' :: stack)
          | (('{' :: st), stack) -> helper st ('{' :: stack)
          | ((')' :: st), ('(' :: stac)) -> helper st stac
          | ((']' :: st), ('[' :: stac)) -> helper st stac
          | (('}' :: st), ('{' :: stac)) -> helper st stac
          | ([], []) -> true
          | ([], _) -> false
          | ((')' :: _), _) -> false
          | ((']' :: _), _) -> false
          | (('}' :: _), _) -> false
          | ((_ :: st), stack) -> helper st stack

      helper [for x in myString -> x] []  

  