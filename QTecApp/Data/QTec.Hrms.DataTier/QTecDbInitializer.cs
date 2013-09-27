namespace QTec.Hrms.DataTier
{
    using System.Data.Entity;

    public class QTecDbInitializer  :DropCreateDatabaseIfModelChanges<QTecDataContext>
    {
        protected override void Seed(QTecDataContext context)
        {
            base.Seed(context);
        }
    }
}