INSERT INTO recipe (recipeID, recipeName, recipeInstructions, cookTime, calories, totalFat, saturatedFat, transFat, cholesterolMG, sodiumMG, totalCarbs, fiber, sugars, protein) VALUES 
(1001, 'Chicken Parmesan', 'chicken_parmesan.json', 45, 845, 37.3, 10.8, 0, 305, 1173, 66.6, 4.8, 8.2, 56),
(1002, 'Chicken Fried Rice', 'chicken_fried_rice.json',60, 700, 20, 4, 0, 170, 1600, 90, 4, 6, 40),
(1003, 'Meat Veggie and Rice Stir-fry', 'meat_veggie_rice_stirfry.json', 30, 760.00, 23.00, 5.00, 0, 85.00, 1050.00, 65.00, 7.00, 5.00, 40.00);

INSERT INTO restriction (restrictionID, restrictionName) VALUES 
(1001, 'Low-carb'),
(1002, 'Keto'),
(1003, 'Vegan'),
(1004, 'Vegetarian'),
(1005, 'Pescatarian'),
(1006, 'Low-fat'),
(1007, 'Paleo'),
(1008, 'Carnivore'),
(1009, 'High-protein'), -- only with a (cal/10)/protein ratio <= 10/7 or 1.43
(1010, 'Gluten-free'),
(1011, 'Dairy-free'),
(1012, 'Nut-free'),
(1013, 'Egg-free'),
(1014, 'Soy-free'),
(1015, 'Grain-free'),
(1016, 'Sugar-free'),
(1017, 'Whole30'),
(1018, 'Mediterranean'),
(1019, 'Quick Meal'); -- 20 min or less

INSERT INTO recipe_restriction (recipeID, restrictionID) VALUES 
(1001, 1004), -- Vegetarian
(1001, 1012), -- Nut-free
(1002, 1006), -- Low-fat
(1002, 1010), -- Gluten-free
(1002, 1011), -- Dairy-free
(1002, 1012), -- Nut-free
(1003, 1010), -- Gluten-free
(1003, 1011), -- Dairy-free
(1003, 1012), -- Nut-free
(1003, 1016); -- Sugar-free


INSERT INTO ingredient (ingredientID, ingredientName) VALUES 
(1001, 'Chicken'),
(1002, 'Egg'),
(2001, 'Basil leaves'),
(2002, 'Red bell pepper'),
(2003, 'Green onions'),
(2004, 'Carrot'),
(2005, 'Green onions'),
(2006, 'Broccoli'),
(2008, 'Yellow bell pepper'),
(2009, 'Frozen peas'),
(4001, 'Spaghetti Pasta'),
(4002, 'Rice'),
(4003, 'Brown rice'),
(4004, 'Breadcrumbs'),
(5001, 'Parmesan cheese'),
(5002, 'Mozzarella cheese'),
(5003, 'Shredded cheese'),
(7001, 'Soy sauce'),
(7002, 'Oyster sauce'),
(8001, 'Salt'),
(8002, 'Vegetable oil'),
(8003, 'Black pepper'),
(8004, 'Sesame oil'),
(8005, 'Olive oil'),
(8006, 'Garlic'),
(8007, 'Black Pepper'),
(9001, 'Marinara sauce');


INSERT INTO recipe_ingredient (recipeID, ingredientID) VALUES 
(1001, 1001), -- Chicken
(1001, 1002), -- Egg
(1001, 2001), -- Basil leaves
(1001, 4001), -- Pasta
(1001, 4002), -- Breadcrumb
(1001, 5001), -- Parmesan cheese
(1001, 5002), -- Mozzarella cheese
(1001, 8001), -- Salt
(1001, 8002), -- Black pepper
(1001, 8003), -- Olive oil
(1001, 9001), -- Marinara sauce
(1002, 1001), -- Chicken
(1002, 1002), -- Egg
(1002, 2003), -- Green onions
(1002, 2004), -- Carrot
(1002, 2009), -- Frozen peas
(1002, 4002), -- Rice
(1002, 7001), -- Soy sauce
(1002, 8001), -- Salt
(1002, 8002), -- Vegetable oil
(1002, 8003), -- Black pepper
(1002, 8004), -- Sesame oil
(1003, 1001), -- Chicken
(1003, 2002), -- Red bell pepper
(1003, 2003), -- Green onions
(1003, 2004), -- Carrot
(1003, 2006), -- Broccoli
(1003, 2008), -- Yellow bell pepper
(1003, 4003), -- Brown rice
(1003, 5003), -- Shredded cheese
(1003, 7001), -- Soy sauce
(1003, 7002), -- Oyster sauce
(1003, 8001), -- Salt
(1003, 8004), -- Sesame oil
(1003, 8005), -- Olive oil
(1003, 8006), -- Garlic
(1003, 8007); -- Black Pepper
