using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipe_Proj.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ingredient",
                columns: table => new
                {
                    IngredientID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IngredientName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredient", x => x.IngredientID);
                });

            migrationBuilder.CreateTable(
                name: "recipe",
                columns: table => new
                {
                    RecipeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RecipeName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    ShortDescription = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    RecipeInstructions = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    CookTime = table.Column<double>(type: "REAL", nullable: false),
                    Calories = table.Column<double>(type: "REAL", nullable: false),
                    TotalFat = table.Column<double>(type: "REAL", nullable: false),
                    SaturatedFat = table.Column<double>(type: "REAL", nullable: false),
                    TransFat = table.Column<double>(type: "REAL", nullable: false),
                    CholesterolMG = table.Column<double>(type: "REAL", nullable: false),
                    SodiumMG = table.Column<double>(type: "REAL", nullable: false),
                    TotalCarbs = table.Column<double>(type: "REAL", nullable: false),
                    Fiber = table.Column<double>(type: "REAL", nullable: false),
                    Sugars = table.Column<double>(type: "REAL", nullable: false),
                    Protein = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe", x => x.RecipeID);
                });

            migrationBuilder.CreateTable(
                name: "recipeUser",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Pass = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipeUser", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "restriction",
                columns: table => new
                {
                    RestrictionID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RestrictionName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restriction", x => x.RestrictionID);
                });

            migrationBuilder.CreateTable(
                name: "recipe_ingredient",
                columns: table => new
                {
                    RecipeID = table.Column<int>(type: "INTEGER", nullable: false),
                    IngredientID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe_ingredient", x => new { x.RecipeID, x.IngredientID });
                    table.ForeignKey(
                        name: "FK_recipe_ingredient_ingredient_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "ingredient",
                        principalColumn: "IngredientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_recipe_ingredient_recipe_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "recipe",
                        principalColumn: "RecipeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recipe_Favorite",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    RecipeID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe_Favorite", x => new { x.UserID, x.RecipeID });
                    table.ForeignKey(
                        name: "FK_recipe_Favorite_recipeUser_UserID",
                        column: x => x.UserID,
                        principalTable: "recipeUser",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_recipe_Favorite_recipe_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "recipe",
                        principalColumn: "RecipeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recipe_restriction",
                columns: table => new
                {
                    RecipeID = table.Column<int>(type: "INTEGER", nullable: false),
                    RestrictionID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe_restriction", x => new { x.RecipeID, x.RestrictionID });
                    table.ForeignKey(
                        name: "FK_recipe_restriction_recipe_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "recipe",
                        principalColumn: "RecipeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_recipe_restriction_restriction_RestrictionID",
                        column: x => x.RestrictionID,
                        principalTable: "restriction",
                        principalColumn: "RestrictionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_recipe_Favorite_RecipeID",
                table: "recipe_Favorite",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_recipe_ingredient_IngredientID",
                table: "recipe_ingredient",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_recipe_restriction_RestrictionID",
                table: "recipe_restriction",
                column: "RestrictionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "recipe_Favorite");

            migrationBuilder.DropTable(
                name: "recipe_ingredient");

            migrationBuilder.DropTable(
                name: "recipe_restriction");

            migrationBuilder.DropTable(
                name: "recipeUser");

            migrationBuilder.DropTable(
                name: "ingredient");

            migrationBuilder.DropTable(
                name: "recipe");

            migrationBuilder.DropTable(
                name: "restriction");
        }
    }
}
