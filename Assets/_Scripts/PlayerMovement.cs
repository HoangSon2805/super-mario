using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody2D rb;
    private float horizontalInput;
    private bool isFacingRight = true; // Biến để theo dõi hướng của nhân vật

    [SerializeField] private float moveSpeed = 5f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // GỌI HÀM LẬT NHÂN VẬT
        Flip();
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    // HÀM MỚI ĐỂ LẬT NHÂN VẬT
    private void Flip() {
        // Nếu đang di chuyển sang trái VÀ nhân vật đang nhìn sang phải
        if (horizontalInput < 0f && isFacingRight)
        {
            // Lật nhân vật và cập nhật lại trạng thái
            transform.localScale = new Vector3(-1f, 1f, 1f);
            isFacingRight = false;
        }
        // Nếu đang di chuyển sang phải VÀ nhân vật đang nhìn sang trái
        else if (horizontalInput > 0f && !isFacingRight)
        {
            // Lật nhân vật lại và cập nhật trạng thái
            transform.localScale = new Vector3(1f, 1f, 1f);
            isFacingRight = true;
        }
    }
}