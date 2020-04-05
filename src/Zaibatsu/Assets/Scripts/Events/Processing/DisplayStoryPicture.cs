
using UnityEngine;

public class DisplayStoryPicture : OnMessage<ShowStoryImage>
{
    [SerializeField] private StoryPictureView view;
    
    protected override void Execute(ShowStoryImage msg)
    {
        view.Set(msg.Image.Sprite, msg.Text);
        view.gameObject.SetActive(true);
    }
}
