import sqlite3
import os

def run_script(cursor, sql_script_path):
    with open(sql_script_path, 'r') as file:
        sql_script = file.read()
    cursor.executescript(sql_script)
    print(f"Script {sql_script_path} ran successfully.")

def run_seed_script(db_path, drop_path, initialize_path, seed_path):
    connection = sqlite3.connect(db_path)
    cursor = connection.cursor()

    try:
        cursor.execute('BEGIN TRANSACTION;')

        run_script(cursor, drop_path)
        run_script(cursor, initialize_path)
        run_script(cursor, seed_path)

        connection.commit()
        print("All scripts executed successfully and committed.")

    except sqlite3.Error as error:
        connection.rollback()
        print(f"Error: {error}")

    finally:
        cursor.close()
        connection.close()
        



db_base_path = os.path.join('Recipe_Proj.Server', 'Database')
db_path = os.path.join(db_base_path, 'recipeDatabase.db')

base_path = 'DatabaseStuff'
drop_path = os.path.join(base_path, 'dontRunPlz.sql')
initialize_path = os.path.join(base_path, 'initializeTables.sql')
seed_path = os.path.join(base_path, 'seedDB.sql')


run_seed_script(db_path, drop_path, initialize_path, seed_path)
