using UnityEngine;
using UnityEngine.Assertions;

public class MyColorChanger : MonoBehaviour
{
    [SerializeField]
    private Renderer _target;

    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip[] _musicClips;

    [SerializeField]
    private CassetteMover[] cassetteMovers;

    private Material _targetMaterial;
    private Color _savedColor;
    private float _lastHue = 0;
    private int _musicIndex = 0;

    public void NextColor()
    {
        _lastHue = (_lastHue + 0.3f) % 1f;
        Color newColor = Color.HSVToRGB(_lastHue, 0.8f, 0.8f);
        _targetMaterial.color = newColor;

        // 先更新音乐 index
        _musicIndex = (_musicIndex + 1) % _musicClips.Length;

        // 播放音乐
        if (_musicClips.Length > 0)
        {
            _audioSource.clip = _musicClips[_musicIndex];
            _audioSource.Play();
        }

        // 触发磁带动画
        if (cassetteMovers != null && cassetteMovers.Length > 0)
        {
            for (int i = 0; i < cassetteMovers.Length; i++)
            {
                if (i == _musicIndex)
                    cassetteMovers[i].FlyOut();
                else
                    cassetteMovers[i].ReturnHome();
            }
        }
    }


    public void Save()
    {
        _savedColor = _targetMaterial.color;
    }

    public void Revert()
    {
        _targetMaterial.color = _savedColor;
    }

    protected virtual void Start()
    {
        Assert.IsNotNull(_target);
        _targetMaterial = _target.material;
        Assert.IsNotNull(_targetMaterial);
        _savedColor = _targetMaterial.color;
    }

    private void OnDestroy()
    {
        Destroy(_targetMaterial);
    }

    // ✅ 临时测试用按键触发（放这里就对了）
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("Pressed N, calling NextColor()");
            NextColor();
        }
    }
}
