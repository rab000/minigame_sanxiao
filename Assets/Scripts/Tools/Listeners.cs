public delegate void Listener();
public delegate void Listener<T>(T arg1);
public delegate void Listener<T, U>(T arg1, U arg2);
public delegate void Listener<T, U, V>(T arg1, U arg2, V arg3);
public delegate bool ListenerB<T, U>(T arg1, U arg2);
