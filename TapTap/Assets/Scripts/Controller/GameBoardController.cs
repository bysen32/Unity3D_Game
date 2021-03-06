﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameBoardController : Controller<GameBoardModel>
{
    private GameBoard GameBoardView;
    private const float COUNTDOWN_TIME = 60;

    [Space(10)]
    [SerializeField]
    [Range(0.5f, 10f)]
    private float SpawnGap;
    [SerializeField]
    [Range(2, 8)]
    private int MaxJellyFishCnt;
    private int MaxMarkID = 1;

    protected override void OnInitialize()
    {
        GameBoardView = GetComponent<GameBoard>();
        foreach(JellyFishModel fish in model.JellyFishs) {
            JellyFishController ctrl = Controller.Instantiate<JellyFishController>("JellyFish", fish);
        }
        model.LeftTime = COUNTDOWN_TIME;
        model.NotifyChange();
        Message.AddListener<JellyFishMessage>("click", OnJellyFishClick);
    }
    
    public void Restart() {
        model.JellyFishs.Clear();
        model.LeftTime = COUNTDOWN_TIME;
        model.Score = 0;
        model.LastSpawnTime = -1f;
        model.NotifyChange();
    }

    protected override void OnModelChanged()
    {
        GameBoardView.SetLeftTime(model.LeftTime);
        GameBoardView.SetScore(model.Score);
    }

    private void Update() {
        if (GameManager.GameStatus != GameStatus.GamePlaying) { return; }
        float temp = model.LeftTime;
        model.LeftTime -= Time.deltaTime;
        if ((int)temp != (int)model.LeftTime) {
            model.NotifyChange();
        }
        if (model.LeftTime < 0) {
            GameStatusMessage msg = new GameStatusMessage();
            msg.Status = GameStatus.GameOver;
            Message.Send<GameStatusMessage>(msg);
        }
        
        if (model.JellyFishs.Count < MaxJellyFishCnt) {
            SpawnJellyFish();
        }
    }

    private void SpawnJellyFish()
    {
        if (model.LastSpawnTime > 0 && Time.time - model.LastSpawnTime < SpawnGap) {
            return;
        }
        model.LastSpawnTime = Time.time;
        JellyFishModel fish = new JellyFishModel();
        JellyFishController ctrl = Controller.Instantiate<JellyFishController>("JellyFish", fish);
        fish.MarkID = MaxMarkID;
        MaxMarkID += 1;
        fish.NotifyChange();
        model.JellyFishs.Add(fish);
    }

    private void OnJellyFishClick(JellyFishMessage msg)
    {
        /*Judge Click*/
        foreach(JellyFishModel fish in model.JellyFishs)
        {
            if (msg.MarkID > fish.MarkID) {
                GameStatusMessage msg2 = new GameStatusMessage();
                msg2.Status = GameStatus.GameOver;
                Message.Send(msg2);
                return;
            }
        }
        model.Score += 1;
        model.NotifyChange();
        foreach (JellyFishModel fish in model.JellyFishs)
        {
            if (fish.MarkID == msg.MarkID) {
                model.JellyFishs.Remove(fish);
                break;
            }
        }
    }
}
