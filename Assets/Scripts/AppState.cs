using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppState : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


class StateContext
{


}

class State
{
    protected StateContext _stateContext;

    public void SetStateContext(StateContext stateContext){
        this._stateContext = stateContext;
    }

    
}
