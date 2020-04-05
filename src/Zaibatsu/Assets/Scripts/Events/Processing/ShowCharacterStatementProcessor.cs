
using UnityEngine;

public class ShowCharacterStatementProcessor : OnMessage<ShowCharacterStatement>
{
    [SerializeField] private ConversationView view; 
    
    protected override void Execute(ShowCharacterStatement msg)
    {
        view.Set(msg.Character.Name, msg.Statement);
        view.gameObject.SetActive(true);
    }
}
