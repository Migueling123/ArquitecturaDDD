  namespace Datos.Persistencia.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        PersonaId = c.Long(nullable: false, identity: true),
                        Rut = c.Int(nullable: false),
                        DV = c.String(nullable: false, maxLength: 1),
                        PrimerNombre = c.String(nullable: false, maxLength: 50),
                        SegundoNombre = c.String(maxLength: 50),
                        Apellido = c.String(maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        FechaCreacion = c.DateTime(nullable: false),
                        Vigente = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonaId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Long(nullable: false, identity: true),
                        PersonaId = c.Long(nullable: false),
                        NombreUsuario = c.String(nullable: false, maxLength: 50),
                        Clave = c.String(nullable: false, maxLength: 100),
                        Vigente = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Persona", t => t.PersonaId)
                .Index(t => t.PersonaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "PersonaId", "dbo.Persona");
            DropIndex("dbo.Usuario", new[] { "PersonaId" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Persona");
        }
    }
}
