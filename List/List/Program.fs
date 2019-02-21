let reverse list=
 let rec newlist s= function
  |[]-> s
  |h::t->newlist(h::s) t in
  newlist [] list
printfn "%A" ( reverse [1;2;3] )