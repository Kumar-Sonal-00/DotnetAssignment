Exercise 10:-
Write an algorithm for accepting the age of user and if the age is valid, check whether the user is a kid, a teenager, an adult or a senior citizen.

Pseudo Code: 

AgeCategory(AGE):
  IF AGE < 0 THEN
    PRINT "Invalid age"
  ELSEIF AGE < 12 THEN
    PRINT "The user is a kid"
  ELSEIF AGE < 18 THEN
    PRINT "The user is a teenager"
  ELSEIF AGE < 60 THEN
    PRINT "The user is an adult"
  ELSE
    PRINT "The user is a senior citizen"
  ENDIF
END
