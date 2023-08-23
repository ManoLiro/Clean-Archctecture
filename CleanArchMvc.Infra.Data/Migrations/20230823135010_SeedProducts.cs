﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchMvc.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql
            ("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
             "VALUES('Caderno Espiral','Caderno Espiral 100 Folhas','7.45','50','caderno1.png','1')");

            migrationBuilder.Sql
            ("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
             "VALUES('Estojo','Estojo Grande','5.65','30','estojo1.png','1')");

            migrationBuilder.Sql
            ("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
             "VALUES('Borracha','Borracha Branca','2.45','80','borracha1.png','1')");

            migrationBuilder.Sql
            ("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" +
             "VALUES('Calculadora','Calculadora Simples','15.95','25','calculadora1.png','2')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products"); 
        }
    }
}
