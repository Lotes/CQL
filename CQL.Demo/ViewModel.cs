using GalaSoft.MvvmLight;
using CQL;
using CQL.Contexts;
using CQL.Contexts.Implementation;
using CQL.SyntaxTree;
using CQL.TypeSystem.Implementation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.Demo
{
    public class ViewModel: ViewModelBase
    {
        public class Subject
        {
            public Subject(string name, int age, int @class)
            {
                Name = name;
                Age = age;
                Class = @class;
            }

            public string Name { get; private set; }
            public int Age { get; private set; }
            public int Class { get; private set; }
        }

        private Subject[] database = new[]
        {
            new Subject("Markus", 31, 14),
            new Subject("Michael", 32, 14),
            new Subject("Frank", 33, 14),
            new Subject("Nico", 34, 4),
            new Subject(null, -1, 0),
            new Subject("Felix", 35, 3),
            new Subject("Nick", 36, 2),
            new Subject("Kai", 37, 1),
        };

        private Query query = Queries.True;

        public ViewModel()
        {
            FilteredSubjects = new ObservableCollection<Subject>();
            var tbuilder = new TypeSystemBuilder();
            var SubjectType = tbuilder.AddType<Subject>("Subject", "Object of interest.");
            SubjectType.AddForeignProperty(IdDelimiter.Dot, "name", sub => sub.Name);
            SubjectType.AddForeignProperty(IdDelimiter.Dot, "age", sub => sub.Age);
            SubjectType.AddForeignProperty(IdDelimiter.Dot, "class", sub => sub.Class);
            var context = new EvaluationScope(tbuilder.Build());
            Context = context;
            Update();
        }

        public Query Query { get { return query; } set { query = value; Update(); RaisePropertyChanged(() => Query); } }

        private void Update()
        {
            FilteredSubjects.Clear();
            if(Query != null)
                foreach (var subject in database)
                {
                    Context.DefineThis(subject);
                    if (Query.Evaluate(Context))
                        FilteredSubjects.Add(subject);
                }
        }

        public IScope<object> Context { get; }

        public ObservableCollection<Subject> FilteredSubjects { get; private set; }
    }
}
