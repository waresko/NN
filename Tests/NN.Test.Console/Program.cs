var state = new State();
var model = new Model();
var product = state * model;
public class State
{
    float GetProduct(Model model)
    {
        return Value * model.Value;
    }
    public static float operator * (State state, Model model)
    {
        return state.GetProduct(model);
    }
    public float Value { get; set; }
}

public class Model
{
    public float Value { get; set; }
}