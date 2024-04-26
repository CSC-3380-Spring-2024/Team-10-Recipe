INSERT INTO recipe (recipeID, recipeName, shortDescription, recipeInstructions, recipeImage, cookTime, calories, totalFat, saturatedFat, transFat, cholesterolMG, sodiumMG, totalCarbs, fiber, sugars, protein) VALUES 
(1001, 'Chicken Parmesan', 'a classic Italian-American dish consisting of breaded and fried chicken cutlets topped with marinara sauce and melted mozzarella cheese', 'chicken_parmesan.json', 'chicken_parmesan', 45, 845, 37.3, 10.8, 0, 305, 1173, 66.6, 4.8, 8.2, 56),
(1002, 'Chicken Fried Rice', 'a savory Asian dish made by stir-frying cooked rice with diced chicken, vegetables, eggs, and soy sauce, creating a flavorful and satisfying meal', 'chicken_fried_rice.json', 'chicken_fried_rice', 60, 700, 20, 4, 0, 170, 1600, 90, 4, 6, 40),
(1003, 'Chicken Veggie and Rice Stir-fry', 'a quick and versatile dish where diced meat, assorted vegetables, and cooked rice are stir-fried together with flavorful sauces, offering a balanced and delicious meal', 'chicken_veggie_rice_stirfry.json', 'chicken_veggie_rice_stirfry', 30, 760.00, 23.00, 5.00, 0, 85.00, 1050.00, 65.00, 7.00, 5.00, 40.00),
(1004, 'Salmon Sushi Bake', 'a salmon sushi bake combines seasoned sushi rice, flaked smoked salmon with spicy mayo, cucumber, avocado, and nori, all baked together and served with soy sauce, pickled ginger, and wasabi.', 'salmon_sushi_bake.json', 'salmon_sushi_bake', 30, 540, 28, 4, 0, 30, 1100, 58, 5, 6, 22),
(1005, 'Steak, Green Beans, and Potatoes', 'savor a classic dinner of juicy steak paired with crispy roasted potatoes and tender-crisp green beans, all seasoned to perfection', 'steak_greenbeans_potatoes.json', 'steak_greenbeans_potatoes', 40, 700, 35, 12, 0.5, 115, 600, 45, 6, 3, 45),
(1006, 'Meat Lasagna', 'savor this classic Meat Lasagna, featuring layers of Italian sausage, ground beef, rich cheeses, and a flavorful tomato sauce, all baked to perfection for a comforting dinner delight.', 'meat_lasagna.json', 'meat_lasagna', 70, 810, 40, 18, 1, 153, 1440, 63, 5.5, 11, 57.5),
(1007, 'Creamy Vegan Pasta with Broccoli', 'a delightful blend of al dente pasta and vibrant broccoli smothered in a lush, vegan white bean sauce, enhanced with a sprinkle of crunchy pine nuts', 'creamy_vegan_pasta_broccoli.json', 'creamy_vegan_pasta_broccoli', 30, 675, 18, 2.25, 0, 0, 225, 100.5, 18, 6, 27),
(1008, 'Blueberry Pie', 'a classic dessert featuring a flaky crust filled with sweet and tart blueberries, subtly enhanced with lemon zest and cinnamon for a delightful flavor', 'blueberry_pie.json', 'blueberry_pie', 50, 330, 15, 9, 0, 80, 300, 45, 3, 22, 3),
(1009, 'BBQ Tri-Tip, Pulled Pork, Mac n Cheese, Roasted Vegetables', 'a hearty meal featuring succulent BBQ tri tip, tender pulled pork, creamy mac and cheese, and roasted broccoli, offering a satisfying balance of flavors and textures', 'bbq_tritip_pulledpork_macncheese_broccoli.json', 'bbq_tritip_pulledpork_macncheese_broccoli', 120, 970, 58, 22, 0, 225, 870, 52, 5, 8, 68);




INSERT INTO ingredient (ingredientID, ingredientName) VALUES 
(1001, 'Chicken'),
(1002, 'Egg'),
(1003, 'Salmon'),
(1004, 'Steak'),
(1005, 'Ground beef'),
(1006, 'Italian sausage'),
(1007, 'Tri tip'),
(1008, 'Pork shoulder'),
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
(2013, 'Green Beans'),
(2014, 'Onion'),
(2015, 'Crushed tomatoes'),
(3001, 'Blueberries'),
(3002, 'Lemon juice'),
(3003, 'Lemon zest'),
(4001, 'Spaghetti Pasta'),
(4002, 'Rice'),
(4003, 'Brown rice'),
(4004, 'Breadcrumbs'),
(4005, 'Potatoes'),
(4006, 'Lasagna noodles'),
(4007, 'Pasta'),
(4008, 'All-purpose flour'),
(4009, 'Macaroni'),
(5001, 'Parmesan cheese'),
(5002, 'Mozzarella cheese'),
(5003, 'Shredded cheese'),
(5004, 'Butter'),
(5005, 'Ricotta cheese'),
(5006, 'Unsalted butter'),
(5007, 'Milk'),
(5008, 'Cheddar cheese'),
(6001, 'Pine nuts'),
(6002, 'White beans'),
(7001, 'Soy sauce'),
(7002, 'Oyster sauce'),
(7003, 'Marinara sauce'),
(7004, 'Mayonnaise'),
(7005, 'Sriracha'),
(7006, 'Tomato sauce'),
(7007, 'Tomato paste'),
(7008, 'Vegetable broth'),
(7009, 'BBQ sauce'),
(7010, 'Apple cider vinegar'),
(8001, 'Salt'),
(8002, 'Vegetable oil'),
(8003, 'Black pepper'),
(8004, 'Sesame oil'),
(8005, 'Olive oil'),
(8006, 'Garlic'),
(8007, 'Fresh rosemary'),
(8008, 'Rice vinegar'),
(8009, 'Wasabi'),
(8010, 'Sugar'),
(8011, 'Fresh parsley'),
(8012, 'Dried basil leaves'),
(8013, 'Italian seasoning'),
(8014, 'Fennel seeds'),
(8015, 'Garlic powder'),
(8016, 'Lemon juice'),
(8017, 'Nutritional yeast'),
(8018, 'Olive oil'),
(8019, 'Onion powder'),
(8020, 'Cinnamon'),
(8021, 'Cornstarch'),
(8022, 'Smoked paprika'),
(8023, 'BBQ spice mix'),
(9001, 'Furikake');




INSERT INTO recipe_ingredient (recipeID, ingredientID) VALUES 
(1001, 1001), -- Chicken
(1001, 1002), -- Egg
(1001, 2001), -- Basil leaves
(1001, 4001), -- Pasta
(1001, 4004), -- Breadcrumb
(1001, 5001), -- Parmesan cheese
(1001, 5002), -- Mozzarella cheese
(1001, 7003), -- Marinara sauce
(1001, 8001), -- Salt
(1001, 8003), -- Black pepper
(1001, 8005), -- Olive oil
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
(1003, 7001), -- Soy sauce
(1003, 7002), -- Oyster sauce
(1003, 8001), -- Salt
(1003, 8003), -- Black Pepper
(1003, 8004), -- Sesame oil
(1003, 8005), -- Olive oil
(1003, 8006), -- Garlic
(1004, 1003), -- Salmon
(1004, 2007), -- Pickled ginger
(1004, 2010), -- Cucumber
(1004, 2011), -- Avocado
(1004, 2012), -- Nori
(1004, 4002), -- Rice
(1004, 7001), -- Soy sauce
(1004, 7004), -- Mayonnaise
(1004, 7005), -- Sriracha
(1004, 8008), -- Rice vinegar
(1004, 8009), -- Wasabi
(1004, 8010), -- Sugar
(1004, 9001), -- Furikake
(1005, 1004), -- Steak
(1005, 2013), -- Green Beans
(1005, 4005), -- Potatoes
(1005, 5004), -- Butter
(1005, 8001), -- Salt
(1005, 8003), -- Black pepper
(1005, 8005), -- Olive oil
(1005, 8006), -- Garlic
(1005, 8007), -- Fresh rosemary
(1006, 1002), -- Egg
(1006, 1005), -- Ground beef
(1006, 1006), -- Italian sausage
(1006, 2014), -- Onion
(1006, 2015), -- Crushed tomatoes
(1006, 4006), -- Lasagna noodles
(1006, 5001), -- Parmesan cheese
(1006, 5002), -- Mozzarella cheese
(1006, 5005), -- Ricotta cheese
(1006, 7006), -- Tomato sauce
(1006, 7007), -- Tomato paste
(1006, 8001), -- Salt
(1006, 8003), -- Black pepper
(1006, 8006), -- Garlic
(1006, 8010), -- Sugar
(1006, 8011), -- Fresh parsley
(1006, 8012), -- Dried basil leaves
(1006, 8013), -- Italian seasoning
(1006, 8014), -- Fennel seeds
(1007, 2006), -- Broccoli
(1007, 4007), -- Pasta
(1007, 6001), -- Pine nuts
(1007, 6002), -- White beans
(1007, 7008), -- Vegetable broth
(1007, 8015), -- Garlic powder
(1007, 8016), -- Lemon juice
(1007, 8017), -- Nutritional yeast
(1007, 8018), -- Olive oil
(1007, 8019), -- Onion powder
(1008, 1002), -- Egg
(1008, 3001), -- Blueberries
(1008, 3002), -- Lemon juice
(1008, 3003), -- Lemon zest
(1008, 4008), -- All-purpose flour
(1008, 5006), -- Unsalted butter
(1008, 8001), -- Salt
(1008, 8010), -- Sugar
(1008, 8020), -- Cinnamon
(1008, 8021), -- Cornstarch
(1009, 1007), -- Tri tip
(1009, 1008), -- Pork shoulder
(1009, 2006), -- Broccoli
(1009, 4009), -- Macaroni
(1009, 5004), -- Butter
(1009, 5007), -- Milk
(1009, 5008), -- Cheddar cheese
(1009, 7009), -- BBQ sauce
(1009, 7010), -- Apple cider vinegar
(1009, 8001), -- Salt
(1009, 8003), -- Black pepper
(1009, 8015), -- Garlic powder
(1009, 8018), -- Olive oil
(1009, 8022), -- Smoked paprika
(1009, 8023); -- BBQ spice mix


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
(1004, 1010), -- Gluten-free
(1004, 1011), -- Dairy-free
(1004, 1012), -- Nut-free
(1004, 1013), -- Egg-free
(1004, 1018), -- Mediterranean
(1005, 1010), -- Gluten-free
(1005, 1012), -- Nut-free
(1005, 1013), -- Egg-free
(1005, 1014), -- Soy-free
(1005, 1015), -- Grain-free
(1006, 1012), -- Nut-free
(1006, 1014), -- Soy-free
(1007, 1003), -- Vegan
(1007, 1004), -- Vegetarian
(1007, 1011), -- Dairy-free
(1007, 1013), -- Egg-free
(1007, 1014), -- Soy-free
(1008, 1004), -- Vegetarian
(1008, 1012), -- Nut-free
(1008, 1014), -- Soy-free
(1008, 1009), -- High-Protein
(1009, 1012), -- Nut-free	
(1009, 1014); -- Soy-free
