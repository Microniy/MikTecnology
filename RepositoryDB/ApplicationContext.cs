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
            modelBuilder.Entity<AssemblyNode>().HasData(
                new AssemblyNode[]
                {
                    new AssemblyNode{ Id=1, Name="СМТШ.684127.064", Description="Система магнитная" },
                    new AssemblyNode{ Id=5, Name="СМТШ.301714.081", Description="Полоса прессующая" },
                    new AssemblyNode{ Id=6, Name="СМТШ.686469.442", Description="Маслоканал" }
                }
                );
            modelBuilder.Entity<DetailNode>().HasData(
                new DetailNode[]
                {
                    new DetailNode{ Id=2, Name="СМТШ.754152.133", Description="Прокладка" },
                    new DetailNode{ Id=3, Name="СМТШ.754152.133-001", Description="Прокладка" },
                    new DetailNode{ Id=4, Name="СМТШ.745226.006", Description="Кронштейн" },
                    new DetailNode{ Id=7, Name="СМТШ.741521.439", Description="Полоса изоляционная" },
                    new DetailNode{ Id=8, Name="СМТШ.741291.167", Description="Планка" },
                    new DetailNode{ Id=9, Name="СМТШ.741138.156", Description="Полоса прессующая"  },
                    new DetailNode{ Id=10, Name="СМТШ.711111.069", Description="Стержень"  },
                    new DetailNode{ Id=11, Name="СМТШ.741171.042", Description="Полоса"  },
                    new DetailNode{ Id=12, Name="СМТШ.741171.042-001", Description="Полоса"  },
                    new DetailNode{ Id=13, Name="СМТШ.741171.042-002", Description="Полоса"  },
                    new DetailNode{ Id=14, Name="СМТШ.741171.042-004", Description="Полоса"  },
                    new DetailNode{ Id=15, Name="СМТШ.741171.042-005", Description="Полоса"  },
                    new DetailNode{ Id=16, Name="СМТШ.741171.042-007", Description="Полоса"  },
                    new DetailNode{ Id=17, Name="СМТШ.741171.042-010", Description="Полоса"  },
                    new DetailNode{ Id=18, Name="СМТШ.741171.042-011", Description="Полоса"  },
                    new DetailNode{ Id=19, Name="СМТШ.741171.042-012", Description="Полоса"  },
                    new DetailNode{ Id=20, Name="СМТШ.741171.042-013", Description="Полоса"  },
                    new DetailNode{ Id=21, Name="СМТШ.741171.042-015", Description="Полоса"  },
                    new DetailNode{ Id=22, Name="СМТШ.741171.042-016", Description="Полоса"  },
                    new DetailNode{ Id=23, Name="СМТШ.741171.042-017", Description="Полоса"  },
                    new DetailNode{ Id=24, Name="СМТШ.741171.042-020", Description="Полоса"  },
                    new DetailNode{ Id=25, Name="СМТШ.741171.042-023", Description="Полоса"  },
                    new DetailNode{ Id=26, Name="СМТШ.741171.042-026", Description="Полоса"  },
                    new DetailNode{ Id=27, Name="СМТШ.741171.042-028", Description="Полоса"  },
                    new DetailNode{ Id=28, Name="СМТШ.741171.042-030", Description="Полоса"  },
                    new DetailNode{ Id=29, Name="СМТШ.741171.042-035", Description="Полоса"  },
                    new DetailNode{ Id=30, Name="СМТШ.741171.042-041", Description="Полоса"  },
                    new DetailNode{ Id=31, Name="СМТШ.741171.042-045", Description="Полоса"  },
                    new DetailNode{ Id=32, Name="СМТШ.741171.042-052", Description="Полоса"  }
                }
                );

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
