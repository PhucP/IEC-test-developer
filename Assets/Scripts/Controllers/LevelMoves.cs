﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMoves : LevelCondition
{
    private int m_moves;

    private BoardController m_board;

    private int _previousMove;

    public override void Setup(float value, Text txt, BoardController board)
    {
        base.Setup(value, txt);

        m_moves = (int)value;
        _previousMove = (int)value;

        m_board = board;

        m_board.OnMoveEvent += OnMove;
        Pool.Instance.OnRestartLevel += OnReset;

        UpdateText();
    }

    private void OnReset()
    {
        m_moves = _previousMove;
    }

    private void OnMove()
    {
        if (m_conditionCompleted) return;

        m_moves--;

        UpdateText();

        if(m_moves <= 0)
        {
            OnConditionComplete();
        }
    }

    protected override void UpdateText()
    {
        m_txt.text = string.Format("MOVES:\n{0}", m_moves);
    }

    protected override void OnDestroy()
    {
        if (m_board != null)
        {
            m_board.OnMoveEvent -= OnMove;
            Pool.Instance.OnRestartLevel += OnReset;
        }

        base.OnDestroy();
    }
}
