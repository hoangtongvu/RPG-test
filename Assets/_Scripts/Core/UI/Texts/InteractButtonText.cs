using Core;
using Core.Interaction;

public class InteractButtonText : BaseText
{


    private void OnEnable()
    {
    }

    private void OnDestroy()
    {
        //this.UnSubEvents(); this will lead to NullReferenceException: SerializedObject of SerializedProperty has been Disposed.
    }

    private void Start()
    {
        this.SubEvents();
        this.Hide();
    }

    private void SubEvents()
    {
        InteractSender interactSender = PlayerManager.Instance.PlayerCtrl.InteractSender;
        interactSender.onEmptyReceivers.AddListener(this.Hide);
        interactSender.onNotEmptyReceivers.AddListener(this.Show);
    }

    private void UnSubEvents()
    {
        InteractSender interactSender = PlayerManager.Instance.PlayerCtrl.InteractSender;
        interactSender.onEmptyReceivers.RemoveListener(this.Hide);
        interactSender.onNotEmptyReceivers.RemoveListener(this.Show);
    }

    private void Show()
    {
        this.gameObject.SetActive(true);
    }

    private void Hide()
    {
        this.gameObject.SetActive(false);
    }

}