# Around Us

A first-person shooter built for the
[Cyma Rubin Visualization Gallery](https://www.lib.ncsu.edu/spaces/cyma-rubin-visualization-gallery)
at NC State, where eight projectors wrap the picture around the room as a single 15360x1080 strip.
Among Us crewmates spawn at random points on a circle around you and walk straight in, so the fight
really is on every side at once — and your only weapon is a paper airplane.

**You turn with the controller's gyroscope** (tilt the pad and the camera follows) **and throw with
the trigger.**

Two of us built it in about three days on top of Phillips Albright's gallery template, below.

- **Play it:** <https://gjgamejam.itch.io/around-us> (Windows download)
- **The gallery:** <https://www.lib.ncsu.edu/spaces/cyma-rubin-visualization-gallery>

## Built on Phillips Albright's gyro template

This project started from
[NCSU-Visualization-Gallery-Gyro-Template](https://github.com/phillipsalbright/NCSU-Visualization-Gallery-Gyro-Template)
by [Phillips Albright](https://github.com/phillipsalbright), which solves the two problems every
gallery project has before it can be a game: driving the eight-projector wraparound display from a
single Unity camera rig, and reading a DualShock 4's gyroscope as a way to aim, since the gallery
has no mouse. Around Us is the game built on that foundation, and the template's camera and input
setup is still what puts it on the wall.

## Controls

| Action | Input |
| --- | --- |
| Turn / aim | Tilt the DualShock 4 — the camera follows its gyroscope |
| Enable gyro aiming | Press the Share button (the controller reports motion only once it is on) |
| Throw a paper airplane | Trigger |
| Without gyro | The sticks work, but the game is meant to be played by pointing the pad |

Survive: one touch from a crewmate ends the run.

## In the gallery

The display is eight 1080p projectors side by side, so the game asks for a single
`15360x1080` window and renders it through eight cameras, one per projector, each writing to its
own render texture (`Camera1`–`Camera8` under `Assets/Textures`). That is why the wall shows a
continuous 360-degree view rather than eight separate images, and why a build run on an ordinary
monitor is letterboxed into a thin strip.

## How it works

Unity, 11 C# scripts under `Assets/Scripts`:

- **`GyroController.cs`** — registers a custom HID layout for the DualShock 4, reads the raw
  gyroscope and accelerometer vectors out of the controller's input report, and integrates the
  deltas into the camera's rotation. This is the template's contribution and the reason the game
  plays by tilt.
- **`CameraBehaviorSetup.cs`** — sets the `15360x1080` resolution and wires the eight cameras to
  their render textures.
- **`EnemySpawner.cs`** — every five seconds, picks a random angle on a circle around the player
  and spawns a crewmate there.
- **`EnemyBehavior.cs`** — each crewmate looks at the player and walks straight in; touching the
  player loads the game-over scene.
- **`paperAirplaneShooter.cs`** — throws a paper airplane from the sight transform on a 0.90 second
  cooldown, so the trigger is paced rather than automatic.
- **`paperAirplaneFlight.cs`** — flies it in a straight line, destroys a crewmate on contact, and
  crumples the airplane into a paper ball if it hits scenery first.

`UI Elements` holds two reticles and both a blue and a red set of scoreboard digits, so the HUD is
laid out for two players.

## Credits

- **Gallery template and gyroscope input:**
  [Phillips Albright](https://github.com/phillipsalbright) —
  [NCSU-Visualization-Gallery-Gyro-Template](https://github.com/phillipsalbright/NCSU-Visualization-Gallery-Gyro-Template)
- **Built by:** [gjGameJam](https://github.com/gjGameJam) and FirebombDragon64
- **Models** (Sketchfab, Creative Commons):
  - "Paper Airplane" by kilansky (CC BY)
  - "Paper Ball (free)" by Lesca 3D-Scan (CC BY-NC)
  - "Among Us Astronaut" by Framed51 (CC BY)
- Among Us is a trademark of Innersloth LLC. This is a student project made for a campus
  installation, not affiliated with or endorsed by Innersloth.

