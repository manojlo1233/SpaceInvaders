using UnityEngine;
using UnityEngine.SceneManagement;

public class MysteryShip : MonoBehaviour
{
    public float speed = 5.0f;
    public int timer = 20;
    private Vector3 _direction = Vector3.right;
    private bool animate = false;

    private void Start()
    {
        InvokeRepeating(nameof(AnimateShip), this.timer, this.timer);
    }

    private void Update()
    {
        if (animate)
        {
            this.transform.position += _direction * this.speed * Time.deltaTime;
            Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
            Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
            if (_direction == Vector3.right && this.transform.position.x >= rightEdge.x + 3)
            {
                this.transform.position = new Vector3(18.0f, 13.0f, 0);
                this.animate = false;
                this._direction.x *= -1.0f;
            }
            else if (_direction == Vector3.left && this.transform.position.x <= leftEdge.x - 3)
            {
                this.transform.position = new Vector3(-18.0f, 13.0f, 0);
                this.animate = false;
                this._direction.x *= -1.0f;
            }
        }
        
    }

    private void AnimateShip()
    {
        animate = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
