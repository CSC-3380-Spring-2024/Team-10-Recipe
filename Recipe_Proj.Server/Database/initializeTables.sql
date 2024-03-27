CREATE TABLE recipe (
  recipeID INTEGER PRIMARY KEY,
  recipeName VARCHAR(255),
  recipeInstructions VARCHAR(255),
  cookTime DECIMAL(10,2),
  calories DECIMAL(10,2),
  totalFat DECIMAL(10,2),
  saturatedFat DECIMAL(10,2),
  transFat DECIMAL(10,2),
  cholesterolMG DECIMAL(10,2),
  sodiumMG DECIMAL(10,2),
  totalCarbs DECIMAL(10,2),
  fiber DECIMAL(10,2),
  sugars DECIMAL(10,2),
  protein DECIMAL(10,2)
);

CREATE TABLE restriction (
  restrictionID INTEGER PRIMARY KEY,
  restrictionName VARCHAR(255)
);

CREATE TABLE recipe_restriction (
  recipeID INTEGER,
  restrictionID INTEGER,
  FOREIGN KEY (recipeID) REFERENCES recipe (recipeID),
  FOREIGN KEY (restrictionID) REFERENCES restriction (restrictionID)
);


CREATE TABLE ingredient (
  ingredientID INTEGER PRIMARY KEY,
  ingredientName VARCHAR(255)
);

CREATE TABLE recipe_ingredient (
  recipeID INTEGER,
  ingredientID INTEGER,
  FOREIGN KEY (recipeID) REFERENCES recipe (recipeID),
  FOREIGN KEY (ingredientID) REFERENCES ingredient (ingredientID)
);


CREATE TABLE recipeUser (
  userID INTEGER PRIMARY KEY,
  firstName VARCHAR(255),
  lastName VARCHAR(255),
  email VARCHAR(255),
  pass VARCHAR(255)
);

CREATE TABLE recipe_Favorite (
  userID INTEGER,
  recipeID INTEGER,
  FOREIGN KEY (userID) REFERENCES recipeUser (userID),
  FOREIGN KEY (recipeID) REFERENCES recipe (recipeID)
);