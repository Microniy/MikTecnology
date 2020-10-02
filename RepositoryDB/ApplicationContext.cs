using System;
using System.IO;
using System.Text.Json;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TecnoComponents;

namespace RepositoryDB
{   
    
    public class ApplicationContext:DbContext
    {
        SqlConnectionStringBuilder sqlConnectionBuild = new SqlConnectionStringBuilder();
        public DbSet<TecnoComponents.Link> Links { get; set; }
        public DbSet<TecnoComponents.BaseInfoObject> BaseInfoObjects { get; set; }
        public DbSet<TecnoComponents.AssemblyNode> AssemblyNodes { get; set; }
        public DbSet<TecnoComponents.DetailNode> DetailNodes { get; set; }
        public ApplicationContext()
        {
            string CriptKey = "!CryptKey7My";
            string jsonString;           
            jsonString = File.ReadAllText(@"D:\ConnectJson.json");
            ConnectBuilderJson ConnectionObj = new ConnectBuilderJson();
            ConnectionObj = JsonSerializer.Deserialize<ConnectBuilderJson>(jsonString);
            sqlConnectionBuild.DataSource = StringCipher.Decrypt(ConnectionObj.DataSource, CriptKey);
            sqlConnectionBuild.InitialCatalog = ConnectionObj.InitialCatalog;
            sqlConnectionBuild.UserID = StringCipher.Decrypt(ConnectionObj.UserID, CriptKey);
            sqlConnectionBuild.Password = StringCipher.Decrypt(ConnectionObj.Password, CriptKey);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(sqlConnectionBuild.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Link>(LinkConfigure);
            modelBuilder.Entity<BaseInfoObject>(BaseInfoObjectConfigure);
            modelBuilder.Entity<AssemblyNode>(AssemblyNodeConfigure);
            modelBuilder.Entity<DetailNode>(DetailNodeConfigure);

        }
        public void LinkConfigure(EntityTypeBuilder<Link> builder)
        {
            builder.HasOne(p => p.InfoDB)
                .WithMany(b => b.DirectLinkDB)
                .HasForeignKey(p=>p.InfoId);
            builder.Property<int>("LinkParentId");           
            builder.HasOne(l=>l.ParentDB)
                .WithMany(l2 => l2.ChildrenDB)
                .HasForeignKey("LinkParentId")
                .IsRequired(false);
                
        }
        public void BaseInfoObjectConfigure(EntityTypeBuilder<BaseInfoObject> builder)
        {
            builder.HasDiscriminator(b => b.TypeNode)
                .HasValue<AssemblyNode>((int)StringTypeNode.AssemblyNode)
                .HasValue<DetailNode>((int)StringTypeNode.DetailNode);           
        }
        public void AssemblyNodeConfigure(EntityTypeBuilder<AssemblyNode> builder)
        {
            builder.Property(a => a.Name)
                .HasColumnName("Name");
            builder.Property(a => a.Number)
                .HasColumnName("Number");
            builder.Property(a => a.Description)
                .HasColumnName("Description");
        }
        public void DetailNodeConfigure(EntityTypeBuilder<DetailNode> builder)
        {
            builder.Property(a => a.Name)
                .HasColumnName("Name");
            builder.Property(a => a.Number)
                .HasColumnName("Number");
            builder.Property(a => a.Description)
                .HasColumnName("Description");
        }

    }
}
