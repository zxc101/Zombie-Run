using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    [SerializeField] private float timeForImmortality;
    [SerializeField] private float hp;
    [SerializeField] private List<Transform> items;
	private AudioSource _takeDamage;
	[SerializeField]
	private Sound[] sounds;

    private float timer;

    public float HP => hp;
	private Sound _idleSound;

	void Awake()
	{
		foreach(Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.Clip;
			s.source.volume = s.Volume;
			s.source.pitch = s.Pitch;
		}
	}
	
	void Start()
	{
		_idleSound = Array.Find(sounds, sound => sound.Name == "Idle");
		_idleSound.source.loop = true;
		_idleSound.source.Play();
	}
    private void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
		_takeDamage = GetComponent<AudioSource>();
    }

    public void Damage(float power)
    {
        if (timer <= 0)
        {
            hp -= 1;
            timer = Time.timeScale + timeForImmortality;
			Play("Damaged");
        }
    }

    public void Heal(float power)
    {
		Play("Healed");
        hp += power;
    }

    public void GetItem(Transform item)
    {
		Play("TakeItem");
        items.Add(item);
    }
	public void Play(string name)
	{
		Sound s = Array.Find(sounds, sound => sound.Name == name);
		s.source.Play();
	}
}
