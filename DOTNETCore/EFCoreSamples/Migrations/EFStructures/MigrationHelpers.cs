﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations.EFStructures;

public static class MigrationHelpers
{
    public static void CreateSproc(MigrationBuilder migrationBuilder)
    {
        var sql = @"
CREATE VIEW [dbo].[CustomerOrderView]
AS
SELECT dbo.Customers.FirstName, dbo.Customers.LastName, dbo.Inventory.Color, dbo.Inventory.PetName, dbo.Makes.Name AS Make
FROM   dbo.Orders 
INNER JOIN dbo.Customers ON dbo.Orders.CustomerId = dbo.Customers.Id 
INNER JOIN dbo.Inventory ON dbo.Orders.CarId = dbo.Inventory.Id
INNER JOIN dbo.Makes ON dbo.Makes.Id = dbo.Inventory.MakeId ";
        migrationBuilder.Sql(sql);
    }
    public static void DropSproc(MigrationBuilder migrationBuilder)
    {
        var sql = @"DROP VIEW [dbo].[CustomerOrders]";
        migrationBuilder.Sql(sql);
    }
}