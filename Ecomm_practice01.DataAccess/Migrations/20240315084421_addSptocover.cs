using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomm_practice01.DataAccess.Migrations
{
    public partial class addSptocover : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {//create
            migrationBuilder.Sql(@"CREATE PROCEDURE createCovertype
	                                @name varchar(50)
                                    AS
	                                    insert into CoverTypes values(@name)");
            //update
            migrationBuilder.Sql(@"CREATE PROCEDURE updateCovertype
	                                @name varchar(50),
                                    @id int
                                    AS
	                                    update CoverTypes set Name=@name where Id=@id");
            //delete
            migrationBuilder.Sql(@"CREATE PROCEDURE deleteCovertype
                                    @id int
                                    AS
	                                    delete from CoverTypes where Id=@id ");
            //find all
            migrationBuilder.Sql(@"CREATE PROCEDURE getCovertypes
                                    AS
	                                    select * from CoverTypes");
            //find one
            migrationBuilder.Sql(@"CREATE PROCEDURE getCovertype
                                    @id int
                                   AS
	                                    select * from CoverTypes where Id =@id");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
