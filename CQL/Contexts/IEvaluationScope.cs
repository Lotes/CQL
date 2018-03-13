namespace CQL.Contexts
{
    /// <summary>
    /// An evaluation scope contains all variables (name and value) for user accessible objects during evaluation (runtime object).
    /// </summary>
    public interface IEvaluationScope: IScope<object, IEvaluationScope, IVariableDefinition>
    {
        
    }
}
