using System;
using Raven.Client.Documents.Session;
using static LaYumba.Functional.F;

namespace RavenExample.Infrastructure.Storage
{
    public class RavenSessionHelper
    {
        public static TResult Open<TResult>(Func<IDocumentSession, TResult> func)
        {
            var store = DocumentStoreHolder.Store;

            using (var session = store.OpenSession())
            {
                return func(session);
            }
        }

        public static void Do(Action<IDocumentSession> operation) => Open(session =>
        {
            operation(session);
            return Unit();
        });
    }
}
