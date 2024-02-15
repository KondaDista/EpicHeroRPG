using System;
using Player;

///<summary>
/// Обёртка для вызова методов с помощтю строки и списка аргументов.
/// Служит для взова функций исходя из данных которые приходят из конфигурационного файла JSON
/// </summary>
public class MethodFromStringExecuter
{
    public static MethodFromStringExecuter Instance { get; private set; }
    
    private Player.Player _player;
    private Inventory _inventory;
    private Game _game;
    
    public MethodFromStringExecuter(Game game, Player.Player player, Inventory inventory)
    {
        Instance = this;
        _player = player;
        _inventory = inventory;
        _game = game;
    }
    
    /// <summary>
    /// Вызывает метод с названием <c>name</c> и параметрами <c>parameters</c>
    /// </summary>
    /// <param name="name">Имя метода</param>
    /// <param name="parameters">Список параметров</param>
    public void InvokeMethod(string name, object[] parameters)
    {
        var method = GetType().GetMethod(name);
        if (method != null)
            method.Invoke(this,  parameters);
    }

    /// <summary>
    /// Вызывает метод с названием <c>name</c> и параметрами <c>parameters</c>.
    /// Возвращает флаг.
    /// </summary>
    /// <param name="name">Имя метода</param>
    /// <param name="parameters">Список параметров</param>
    /// <returns>Выполненно ли условие</returns>
    public bool InvokeConditionMethod(string name, object[] parameters)
    {
        var method = GetType().GetMethod(name);
        if (method != null)
            return (bool) method.Invoke(this,  parameters);
        return false;
    }

    #region Actions

    public void ChangeItemsInInventoryByID(int id, int count) =>
        _inventory.ChangeItemInInventoryAt(id, count);
    
    public void Win() =>
        _game.Win();

    public void Lose() =>
        _game.Lose();
    
    #endregion
    
    #region Conditions
    
    // Дальше тут будет реализация задач 2 недели
    
    #endregion
}