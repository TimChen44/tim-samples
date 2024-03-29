﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InterceptorDemo.Models;

public partial class EFDemoContext : DbContext
{
    public EFDemoContext()
    {
    }

    public EFDemoContext(DbContextOptions<EFDemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Company { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder
        .AddInterceptors(new SetAuditInterceptor())
        .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EFDemo;Integrated Security=True");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Chinese_PRC_CI_AS");

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK_Company_1");

            entity.Property(e => e.CompanyId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}