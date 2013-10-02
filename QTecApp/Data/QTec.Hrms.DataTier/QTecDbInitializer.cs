namespace QTec.Hrms.DataTier
{
    using System;
    using System.Data.Entity;

    using QTec.Hrms.DataTier.Migrations;
    using QTec.Hrms.Models;

    /// <summary>
    /// The Database initializer.
    /// </summary>
    public class QTecDbInitializer : MigrateDatabaseToLatestVersion<QTecDataContext, Configuration>
    {
      
    }
}