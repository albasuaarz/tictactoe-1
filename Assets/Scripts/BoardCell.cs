using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoardCell : MonoBehaviour
{
    [SerializeField] public int row;
    [SerializeField] public int col;

    [SerializeField] private Sprite imageX;
    [SerializeField] private Sprite imageO;
    private Image spriteRenderer;
    private Sprite _spriteDefault;

    //[SerializeField] private TextMeshProUGUI cellText;

    //[SerializeField] private UIManager uiManager;

    private void Awake() { 
        spriteRenderer = GetComponent<Image>();
        _spriteDefault = spriteRenderer.sprite;
    }

    // respuesta al onClick
    public void OnClick()
    {
        if (GameManager.Instance.IsGameOver)
        {
            return;
        }

        // Intentar hacer la jugada
        //if
        GameManager.Instance.PlayMove(row, col);
        //{            uiManager.UpdateUI();        }
    }

    public void Refresh()
    {
        CellState state = GameManager.Instance.Board[row, col];
        if (state == CellState.X)
        {
            spriteRenderer.sprite = imageX;
        }
        else if (state == CellState.O)
        {
            spriteRenderer.sprite = imageO;
        }
        else {
            spriteRenderer.sprite = _spriteDefault;
        }

        //cellText.text = (state == CellState.Empty) ? "" : state.ToString();
    }

    private void Update()
    {
        Refresh();
    }
}
