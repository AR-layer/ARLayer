using System;


class StateContext
{
    private State currState;

    public void TransitionTo(State state)
    {
        Console.WriteLine($"������� � ���������:{state.ToString()}");
        currState = state;
    }   

    public void Request1()
    {
        currState.Handle1();
    }

    public void Request2()
    {
        currState.Handle2();
    }
}

abstract class State
{
    protected StateContext _context;

    public void SetStateContext(StateContext newContext)
    {
        _context = newContext;
    }

    public abstract void Handle1();
    public abstract void Handle2();
}

class Navigation : State
{
    public override void Handle1()
    {
        Console.WriteLine("��������� ��������� ������������ ������ ������");
    }

    public override void Handle2()
    {
        Console.WriteLine("���������� ������� � ��������� ������ �������");
        _context.TransitionTo(new Scanning());
    }
}

class Scanning : State
{
    public override void Handle1()
    {
        Console.WriteLine("��������� ������������ ������������ ������ ������");
    }

    public override void Handle2()
    {
        Console.WriteLine("���������� ������� � ��������� ���������");
        _context.TransitionTo(new Navigation());
    }
}