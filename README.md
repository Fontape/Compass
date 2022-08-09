# Compass
[![build ci norules](https://github.com/Fontape/Compass/actions/workflows/build-ci-norules.yml/badge.svg)](https://github.com/Fontape/Compass/actions/workflows/build-ci-norules.yml)
<a href="https://github.com/Fontape/Compass/releases">
  <img src="https://img.shields.io/github/release/Fontape/Compass/all.svg?style=flat" alt="GitHub Releases">
</a>
![Github All Downloads](https://img.shields.io/github/downloads/Fontape/Compass/total.svg?style=flat)
![Github Commits](https://img.shields.io/github/commit-activity/w/Fontape/Compass/main)
### Description

This plugin adds a <b>compass</b> to the SCP: Secret Laboratory. The compass shows to player facing azimuth and cardinal direction. 
This can help players in skirmishes. For example, they will be able to draw the attention of allies to the direction in which they noticed the enemy.<br/>
Also, compass just adds some charm to the game.

<b>Attention! The compass is updated on average about 10 times per second, and uses broadcasts for this. 
This means that using this plugin, all players who have the compass enabled will not be able to see your custom broadcasts. 
If you need such functionality, consider moving your broadcasts to hints.</b>

### Preview
[![Preview video](https://img.youtube.com/vi/qKisIHMzFB0/0.jpg)](https://www.youtube.com/watch?v=qKisIHMzFB0)

### Visibility modes

There are several compass visibility modes available in the plugin config:
Mode Name | Description
:---: | :---
Humans | Implies that the compass will be visible to all players of the human classes.
FirearmHolders | Compass will only be visible to players who hold a firearm.
SquadMembers | Compass will be visible to players whose classes belong to MTF or CI team.

### Translation 

Plugin supports a world sides translations.

### Explanation of `== false`

In code, you may come across the use comparison of `false` via `==`. This is one of the our code notations - we don't use `!`, to make code <b>cleaner</b>.

It is unusual for many developers to put up with this, but, in this case, this is the idea of the plugin authors, and <b>not</b> bad code.
