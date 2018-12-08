using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VikingCrewTools.UI;

public static class Services {


	private static AudioSystem _audio;
	public static AudioSystem Audio     
	{         
		get 
		{             
			Debug.Assert(_audio != null);             
			return _audio;
		}         
		set 
		{ 
			_audio = value; 
		}     
	}

    private static PlayerController _player;
    public static PlayerController Player
    {
        get
        {
            Debug.Assert(_player != null);
            return _player;
        }
        set
        {
            _player = value;

        }
    }

    private static CameraController _camera;
    public static CameraController Camera
    {
        get
        {
            Debug.Assert(_camera != null);
            return _camera;
        }
        set
        {
            _camera = value;
        }
    }

    private static SpeechBubbleManager _speechBubble;
    public static SpeechBubbleManager SpeechBubble
    {
        get
        {
            Debug.Assert(_speechBubble != null);
            return _speechBubble;
        }
        set
        {
            _speechBubble = value;
        }
    }

    private static CutsceneController _cutceneController;
    public static CutsceneController CutsceneController
    {
        get
        {
            Debug.Assert(_cutceneController != null);
            return _cutceneController;
        }
        set
        {
            _cutceneController = value;
        }
    }

    private static PlayerFeetScript _playerFeet;
    public static PlayerFeetScript PlayerFeet
    {
        get
        {
            Debug.Assert(_playerFeet != null);
            return _playerFeet;
        }
        set
        {
            _playerFeet = value;
        }
    }

    private static PrefabDB _prefabDB;
    public static PrefabDB PrefabDB
    {
        get
        {
            Debug.Assert(_prefabDB != null);
            return _prefabDB;
        }
        set
        {
            _prefabDB = value;
        }
    }

    private static SoundManager _soundManager;
    public static SoundManager SoundManager
    {
        get
        {
            Debug.Assert(_soundManager != null);
            return _soundManager;
        }
        set
        {
            _soundManager = value;
        }
    }

    private static MyGameManager _gm;
    public static MyGameManager GameManager
    {
        get
        {
            Debug.Assert(_gm != null);
            return _gm;
        }
        set
        {
            _gm = value;
        }
    }

    private static MyEventManager _event_manager;
	public static MyEventManager Event_Manager
	{
		get
		{
			Debug.Assert (_event_manager != null);
			return _event_manager;
		}
		set{
			_event_manager = value;
		}
	}

	private static LevelManager _level_manager;
	public static LevelManager Level_Manager
	{
		get
		{
			Debug.Assert (_level_manager != null);
			return _level_manager;
		}
		set{
			_level_manager = value;
		}
	}

	private static ObjectPools _objects;
	public static ObjectPools Objects
	{
		get
		{
			Debug.Assert(_objects != null);
			return _objects;
		}
		set
		{
			_objects = value;
		}
	}

	private static Config _config;
	public static Config Config
	{
		get
		{
			Debug.Assert(_config != null);
			return _config;
		}
		set
		{
			_config = value;
		}
		
	}

}
