using PRAPristupBazi.DAL;
using PRAPristupBazi.DAL.DatabaseAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.AutorAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.DrzavaAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.GradAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.IzdavacAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.KnjigaAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.KnjizaraAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.KorisnikAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.OsobaAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.PosudbaAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.RacunAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.StanjeKnjigeAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.StavkaAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.UlogaUaplikacijiAccess;
using PRAPristupBazi.DAL.DatabaseAccess.EntityAccess.ZakasninaPoDanuAccess;
using PRAPristupBazi.Models;
using System.Security.Cryptography;
using System.Text;

Console.WriteLine("Hello, World!");
Console.WriteLine();


// Scaffold-DbContext 'Server=DESKTOP-GS9MV53; Database=PRAKnjizara; Trusted_Connection=True; MultipleActiveResultSets=True' Microsoft.EntityFrameworkCore.SqlServer -Context KnjizaraContext -ContextDir DAL -OutputDir Models -Force


// ENTITYFRAMEWORK PACKAGES:
/*
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.EntityFrameworkCore.Proxies
*/

// ADDITIONAL PACKAGES:
/*
Install-Package System.Security.Cryptography.Algorithms
*/

