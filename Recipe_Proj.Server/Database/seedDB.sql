INSERT INTO recipe (recipeID, recipeName, shortDescription, recipeInstructions, recipeImage, cookTime, calories, totalFat, saturatedFat, transFat, cholesterolMG, sodiumMG, totalCarbs, fiber, sugars, protein) VALUES 
(1001, 'Chicken Parmesan', 'a classic Italian-American dish consisting of breaded and fried chicken cutlets topped with marinara sauce and melted mozzarella cheese', 'chicken_parmesan.json', 'chicken_parmesan', 45, 845, 37.3, 10.8, 0, 305, 1173, 66.6, 4.8, 8.2, 56),
(1002, 'Chicken Fried Rice', 'a savory Asian dish made by stir-frying cooked rice with diced chicken, vegetables, eggs, and soy sauce, creating a flavorful and satisfying meal', 'chicken_fried_rice.json', 'chicken_fried_rice', 60, 700, 20, 4, 0, 170, 1600, 90, 4, 6, 40),
(1003, 'Chicken Veggie and Rice Stir-fry', 'a quick and versatile dish where diced meat, assorted vegetables, and cooked rice are stir-fried together with flavorful sauces, offering a balanced and delicious meal', 'chicken_veggie_rice_stirfry.json', 'chicken_veggie_rice_stirfry', 30, 760.00, 23.00, 5.00, 0, 85.00, 1050.00, 65.00, 7.00, 5.00, 40.00),
(1004,'Salmon Sushi Bake', 'a salmon sushi bake combines seasoned sushi rice, flaked smoked salmon with spicy mayo, cucumber, avocado, and nori, all baked together and served with soy sauce, pickled ginger, and wasabi.', 'salmon_sushi_bake.json', 'salmon_sushi_bake', 30, 540, 28, 4, 0, 30, 1100, 58, 5, 6, 22);

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
(1001, 1012), -- Nut-free
(1002, 1006), -- Low-fat
(1002, 1010), -- Gluten-free
(1002, 1011), -- Dairy-free
(1002, 1012), -- Nut-free
(1003, 1010), -- Gluten-free
(1003, 1011), -- Dairy-free
(1003, 1012), -- Nut-free
(1003, 1016), -- Sugar-free
(1004, 1005), -- Pescatarian
(1004, 1009), -- High-protein
(1004, 1010), -- Gluten-free
(1004, 1011), -- Dairy-free
(1004, 1012), -- Nut-free
(1004, 1013), -- Egg-free
(1004, 1018); -- Mediterranean


INSERT INTO ingredient (ingredientID, ingredientName) VALUES 
(1001, 'Chicken'),
(1002, 'Egg'),
(1003, 'Salmon'),
(2001, 'Basil leaves'),
(2002, 'Red bell pepper'),
(2003, 'Green onions'),
(2004, 'Carrot'),
(2005, 'Green onions'),
(2006, 'Broccoli'),
(2007, 'Pickled ginger'),
(2008, 'Yellow bell pepper'),
(2009, 'Frozen peas'),
(2010, 'Cucumber'),
(2011, 'Avocado'),
(2012, 'Nori'),
(4001, 'Spaghetti Pasta'),
(4002, 'Rice'),
(4003, 'Brown rice'),
(4004, 'Breadcrumbs'),
(5001, 'Parmesan cheese'),
(5002, 'Mozzarella cheese'),
(5003, 'Shredded cheese'),
(7001, 'Soy sauce'),
(7002, 'Oyster sauce'),
(7003, 'Marinara sauce'),
(7004, 'Mayonnaise'),
(7005, 'Sriracha'),
(8001, 'Salt'),
(8002, 'Vegetable oil'),
(8003, 'Black pepper'),
(8004, 'Sesame oil'),
(8005, 'Olive oil'),
(8006, 'Garlic'),
(8007, 'Black Pepper'),
(8008, 'Rice vinegar'),
(8009, 'Wasabi'),
(8010, 'Sugar'),
(9001, 'Furikake');


INSERT INTO recipe_ingredient (recipeID, ingredientID) VALUES 
(1001, 1001), -- Chicken
(1001, 1002), -- Egg
(1001, 2001), -- Basil leaves
(1001, 4001), -- Pasta
(1001, 4004), -- Breadcrumbs
(1001, 5001), -- Parmesan cheese
(1001, 5002), -- Mozzarella cheese
(1001, 7003), -- Marinara sauce
(1001, 8001), -- Salt
(1001, 8002), -- Black pepper
(1001, 8003), -- Olive oil
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
(1003, 8007), -- Black Pepper
(1004, 1003), -- Salmon
(1004, 2010), -- Cucumber
(1004, 2011), -- Avocado
(1004, 2012), -- Nori
(1004, 2007), -- Pickled ginger
(1004, 7004), -- Mayonnaise
(1004, 7005), -- Sriracha
(1004, 7001), -- Soy sauce
(1004, 4002), -- Rice
(1004, 8008), -- Rice vinegar
(1004, 8010), -- Sugar
(1004, 8009), -- Wasabi
(1004, 9001); -- Furikake
