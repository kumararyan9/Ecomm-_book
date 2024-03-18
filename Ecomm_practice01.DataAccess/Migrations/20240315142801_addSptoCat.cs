using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomm_practice01.DataAccess.Migrations
{
    public partial class addSptoCat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //create
            migrationBuilder.Sql(@"CREATE PROCEDURE createCategory
	                                @name varchar(50)
                                    AS
	                                    insert into Categories values(@name)");
            //update
            migrationBuilder.Sql(@"CREATE PROCEDURE updateCategory
	                                @name varchar(50),
                                    @id int
                                    AS
	                                    update Categories set Name=@name where Id=@id");
            //delete
            migrationBuilder.Sql(@"CREATE PROCEDURE deleteCategory
                                    @id int
                                    AS
	                                    delete from Categories where Id=@id ");
            //find all
            migrationBuilder.Sql(@"CREATE PROCEDURE getCategories
                                    AS
	                                    select * from Categories");
            //find one
            migrationBuilder.Sql(@"CREATE PROCEDURE getCategory
                                    @id int
                                   AS
	                                    select * from Categories where Id =@id");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
