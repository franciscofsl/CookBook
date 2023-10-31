﻿// <auto-generated />
using System;
using CookBook.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CookBook.Infrastructure.Data.Migrations
{
    [ExcludeFromCodeCoverage]
    [DbContext(typeof(CookBookDbContext))]
    partial class CookBookDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CookBook.Core.Recipes.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDraft")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("CookBook.Core.Recipes.Recipe", b =>
                {
                    b.OwnsOne("CookBook.Core.Recipes.Ingredients", "Ingredients", b1 =>
                        {
                            b1.Property<Guid>("RecipeId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("RecipeId");

                            b1.ToTable("Recipes");

                            b1.ToJson("Ingredients");

                            b1.WithOwner()
                                .HasForeignKey("RecipeId");

                            b1.OwnsMany("CookBook.Core.Recipes.ValueObjects.IngredientLine", "Lines", b2 =>
                                {
                                    b2.Property<Guid>("IngredientsRecipeId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int");

                                    b2.Property<string>("Description")
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<int>("Order")
                                        .HasColumnType("int");

                                    b2.Property<string>("Type")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("IngredientsRecipeId", "Id");

                                    b2.ToTable("Recipes");

                                    b2.WithOwner()
                                        .HasForeignKey("IngredientsRecipeId");
                                });

                            b1.Navigation("Lines");
                        });

                    b.OwnsOne("CookBook.Core.Recipes.ValueObjects.PreparationTime", "PreparationTime", b1 =>
                        {
                            b1.Property<Guid>("RecipeId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int?>("Hours")
                                .HasColumnType("int");

                            b1.Property<int?>("Minutes")
                                .HasColumnType("int");

                            b1.HasKey("RecipeId");

                            b1.ToTable("Recipes");

                            b1.ToJson("PreparationTime");

                            b1.WithOwner()
                                .HasForeignKey("RecipeId");
                        });

                    b.OwnsOne("CookBook.Core.Recipes.ValueObjects.Ratings", "Ratings", b1 =>
                        {
                            b1.Property<Guid>("RecipeId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("RecipeId");

                            b1.ToTable("Recipes");

                            b1.ToJson("Ratings");

                            b1.WithOwner()
                                .HasForeignKey("RecipeId");

                            b1.OwnsMany("CookBook.Core.Recipes.ValueObjects.Score", "Scores", b2 =>
                                {
                                    b2.Property<Guid>("RatingsRecipeId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int");

                                    b2.Property<string>("Message")
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<int>("Value")
                                        .HasColumnType("int");

                                    b2.HasKey("RatingsRecipeId", "Id");

                                    b2.ToTable("Recipes");

                                    b2.WithOwner()
                                        .HasForeignKey("RatingsRecipeId");
                                });

                            b1.Navigation("Scores");
                        });

                    b.OwnsOne("CookBook.Core.Recipes.ValueObjects.RecipeDescription", "Description", b1 =>
                        {
                            b1.Property<Guid>("RecipeId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Description")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("RecipeId");

                            b1.ToTable("Recipes");

                            b1.WithOwner()
                                .HasForeignKey("RecipeId");
                        });

                    b.OwnsOne("CookBook.Core.Recipes.ValueObjects.RecipeTitle", "Title", b1 =>
                        {
                            b1.Property<Guid>("RecipeId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Title")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("RecipeId");

                            b1.ToTable("Recipes");

                            b1.WithOwner()
                                .HasForeignKey("RecipeId");
                        });

                    b.Navigation("Description");

                    b.Navigation("Ingredients");

                    b.Navigation("PreparationTime");

                    b.Navigation("Ratings");

                    b.Navigation("Title");
                });
#pragma warning restore 612, 618
        }
    }
}
