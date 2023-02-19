using InterceptorDemo.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

EFDemoContext context = new EFDemoContext();

Company company = new Company()
{
    CompanyId = Guid.NewGuid(),
    Title = "超超",
};

context.Add(company);

context.SaveChanges();


public interface IAudit
{
    public string ModifyUser { get; set; }

    public DateTime? ModifyTime { get; set; }
}

public class SetAuditInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            if (entry.Entity is IAudit audit)
            {
                audit.ModifyUser = "超超";
                audit.ModifyTime = DateTime.Now;
            }
        }
        return base.SavingChanges(eventData, result);
    }
}


//Docs:https://learn.microsoft.com/zh-cn/ef/core/logging-events-diagnostics/interceptors#savechanges-interception?WT.mc_id=DT-MVP-5004310
