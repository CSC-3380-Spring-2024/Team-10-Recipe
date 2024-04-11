CREATE TABLE recipe (
  recipeID INTEGER PRIMARY KEY AUTOINCREMENT,
  recipeName TEXT,
  shortDescription TEXT,
  recipeInstructions TEXT,
  cookTime REAL,
  calories REAL,
  totalFat REAL,
  saturatedFat REAL,
  transFat REAL,
  cholesterolMG REAL,
  sodiumMG REAL,
  totalCarbs REAL,
  fiber REAL,
  sugars REAL,
  protein REAL
);

CREATE TABLE restriction (
  restrictionID INTEGER PRIMARY KEY AUTOINCREMENT,
  restrictionName TEXT
);

CREATE TABLE recipe_restriction (
  recipeID INTEGER,
  restrictionID INTEGER,
  FOREIGN KEY (recipeID) REFERENCES recipe (recipeID) ON DELETE CASCADE ON UPDATE NO ACTION,
  FOREIGN KEY (restrictionID) REFERENCES restriction (restrictionID) ON DELETE CASCADE ON UPDATE NO ACTION,
  PRIMARY KEY (recipeID, restrictionID)
);

CREATE TABLE ingredient (
  ingredientID INTEGER PRIMARY KEY AUTOINCREMENT,
  ingredientName TEXT
);

CREATE TABLE recipe_ingredient (
  recipeID INTEGER,
  ingredientID INTEGER,
  FOREIGN KEY (recipeID) REFERENCES recipe (recipeID) ON DELETE CASCADE ON UPDATE NO ACTION,
  FOREIGN KEY (ingredientID) REFERENCES ingredient (ingredientID) ON DELETE CASCADE ON UPDATE NO ACTION,
  PRIMARY KEY (recipeID, ingredientID)
);

CREATE TABLE recipeUser (
  userID INTEGER PRIMARY KEY AUTOINCREMENT,
  firstName TEXT,
  lastName TEXT,
  email TEXT UNIQUE,
  pass TEXT
);

CREATE TABLE recipe_Favorite (
  userID INTEGER,
  recipeID INTEGER,
  FOREIGN KEY (userID) REFERENCES recipeUser (userID) ON DELETE CASCADE ON UPDATE NO ACTION,
  FOREIGN KEY (recipeID) REFERENCES recipe (recipeID) ON DELETE CASCADE ON UPDATE NO ACTION,
  PRIMARY KEY (userID, recipeID)
);