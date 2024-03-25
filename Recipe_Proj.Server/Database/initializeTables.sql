CREATE TABLE recipe (
  recipeID INTEGER PRIMARY KEY,
  recipeName VARCHAR(255),
  recipeInstructions VARCHAR(255),
  cookTime VARCHAR(255),
  calories INTEGER,
  totalFat INTEGER,
  saturatedFat INTEGER,
  transFat INTEGER,
  cholesterolMG INTEGER,
  sodiumMG INTEGER,
  totalCarbs INTEGER,
  fiber INTEGER,
  sugars INTEGER,
  protein INTEGER
);

CREATE TABLE restriction (
  restrictionID INTEGER PRIMARY KEY,
  name VARCHAR(255)
);

CREATE TABLE ingredient (
  ingredientID INTEGER PRIMARY KEY,
  name VARCHAR(255)
);

CREATE TABLE recipe_ingredient (
  recipeID INTEGER,
  ingredientID INTEGER,
  FOREIGN KEY (recipeID) REFERENCES recipe (recipeID),
  FOREIGN KEY (ingredientID) REFERENCES ingredient (ingredientID)
);

CREATE TABLE recipe_restriction (
  recipeID INTEGER,
  restrictionID INTEGER,
  FOREIGN KEY (recipeID) REFERENCES recipe (recipeID),
  FOREIGN KEY (restrictionID) REFERENCES restriction (restrictionID)
);

CREATE TABLE recipeUser (
  userID INTEGER PRIMARY KEY,
  firstName VARCHAR(255),
  lastName VARCHAR(255),
  email VARCHAR(255),
  pass VARCHAR(255)
);

CREATE TABLE recipeFavorite (
  userID INTEGER,
  recipeID INTEGER,
  FOREIGN KEY (userID) REFERENCES recipeUser (userID),
  FOREIGN KEY (recipeID) REFERENCES recipe (recipeID)
);