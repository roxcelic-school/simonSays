using UnityEngine;

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace sys {
    public enum damageTypes {
        Void,
        Base
    }

    public class data {
        // commands
            public static Dictionary<string, eevee.config> config = new Dictionary<string, eevee.config>() {
                // movement
                {
                    "right", new eevee.config {
                        displayName = "right",
                        KEYBOARD_code = (int)KeyCode.D,
                        CONTROLLER_name = "Left Stick Right"
                    }
                },
                {
                    "left", new eevee.config {
                        displayName = "left",
                        KEYBOARD_code = (int)KeyCode.A,
                        CONTROLLER_name = "Left Stick Left"
                    }
                },
                {
                    "up", new eevee.config {
                        displayName = "up",
                        KEYBOARD_code = (int)KeyCode.W,
                        CONTROLLER_name = "Left Stick Up"
                    }
                },
                {
                    "down", new eevee.config {
                        displayName = "down",
                        KEYBOARD_code = (int)KeyCode.S,
                        CONTROLLER_name = "Left Stick Down"
                    }
                },
                {
                    "ground-pound", new eevee.config {
                        displayName = "ground-pound",
                        KEYBOARD_code = (int)KeyCode.LeftControl,
                        CONTROLLER_name = "Left Stick Down"
                    }
                },
                {
                    "jump", new eevee.config {
                        displayName = "jump",
                        KEYBOARD_code = (int)KeyCode.Space,
                        CONTROLLER_name = "Left Stick Down"
                    }
                },
                // attack
                {
                    "guard", new eevee.config {
                        displayName = "guard",
                        KEYBOARD_code = (int)KeyCode.Q,
                        CONTROLLER_name = "X"
                    }
                },
                {
                    "dash", new eevee.config {
                        displayName = "dash",
                        KEYBOARD_code = (int)KeyCode.X,
                        CONTROLLER_name = "Right Trigger"
                    }
                },
                {
                    "attack", new eevee.config {
                        displayName = "attack",
                        KEYBOARD_code = (int)KeyCode.C,
                        CONTROLLER_name = "Right Trigger"
                    }
                },
                // special attack directions
                {
                    "attack-L", new eevee.config {
                        displayName = "attack-L",
                        KEYBOARD_code = (int)KeyCode.LeftArrow,
                        CONTROLLER_name = ""
                    }
                },
                {
                    "attack-R", new eevee.config {
                        displayName = "attack-R",
                        KEYBOARD_code = (int)KeyCode.RightArrow,
                        CONTROLLER_name = ""
                    }
                },
                {
                    "attack-U", new eevee.config {
                        displayName = "attack-U",
                        KEYBOARD_code = (int)KeyCode.UpArrow,
                        CONTROLLER_name = ""
                    }
                },
                {
                    "attack-D", new eevee.config {
                        displayName = "attack-D",
                        KEYBOARD_code = (int)KeyCode.DownArrow,
                        CONTROLLER_name = ""
                    }
                },
                // special attack
                {
                    "special", new eevee.config {
                        displayName = "special",
                        KEYBOARD_code = (int)KeyCode.Return,
                        CONTROLLER_name = ""
                    }
                },
                {
                    "pause", new eevee.config {
                        displayName = "pause",
                        KEYBOARD_code = (int)KeyCode.Escape,
                        CONTROLLER_name = "Start"
                    }
                },
                // menu
                {
                    "MenuLeft", new eevee.config {
                        displayName = "MenuLeft",
                        KEYBOARD_code = (int)KeyCode.LeftArrow,
                        CONTROLLER_name = "Left Stick Left"
                    }
                },
                {
                    "MenuRight", new eevee.config {
                        displayName = "MenuRight",
                        KEYBOARD_code = (int)KeyCode.RightArrow,
                        CONTROLLER_name = "Left Stick Right"
                    }
                },
                {
                    "MenuUp", new eevee.config {
                        displayName = "MenuUp",
                        KEYBOARD_code = (int)KeyCode.UpArrow,
                        CONTROLLER_name = "Left Stick Up"
                    }
                },
                {
                    "MenuDown", new eevee.config {
                        displayName = "MenuDown",
                        KEYBOARD_code = (int)KeyCode.DownArrow,
                        CONTROLLER_name = "Left Stick Down"
                    }
                },
                {
                    "MenuSelect", new eevee.config {
                        displayName = "MenuSelect",
                        KEYBOARD_code = (int)KeyCode.C,
                        CONTROLLER_name = "A"
                    }
                },
                {
                    "MenuBack", new eevee.config {
                        displayName = "MenuBack",
                        KEYBOARD_code = (int)KeyCode.X,
                        CONTROLLER_name = "A"
                    }
                },
                // harrisons controls
                {
                    "HMeleeAttack", new eevee.config {
                        displayName = "HMeleeAttack",
                        KEYBOARD_code = (int)KeyCode.Mouse0,
                        CONTROLLER_name = "X"
                    }
                },
                {
                    "HRangedAttack", new eevee.config {
                        displayName = "HRangedAttack",
                        KEYBOARD_code = (int)KeyCode.Mouse2,
                        CONTROLLER_name = "B"
                    }
                },
                {
                    "HDefend", new eevee.config {
                        displayName = "HDefend",
                        KEYBOARD_code = (int)KeyCode.Q,
                        CONTROLLER_name = "A"
                    }
                },
                {
                    "HOverdrive", new eevee.config {
                        displayName = "HOverdrive",
                        KEYBOARD_code = (int)KeyCode.E,
                        CONTROLLER_name = "Y"
                    }
                },
                {
                    "HDash", new eevee.config {
                        displayName = "HDash",
                        KEYBOARD_code = (int)KeyCode.LeftShift,
                        CONTROLLER_name = "Y"
                    }
                },
                // debug
                {
                    "reset", new eevee.config {
                        displayName = "reset",
                        KEYBOARD_code = (int)KeyCode.R,
                        CONTROLLER_name = "Y"
                    }
                },
                {
                    "commandBarOpen", new eevee.config {
                        displayName = "commandBarOpen",
                        KEYBOARD_code = (int)KeyCode.Q,
                        CONTROLLER_name = "start"
                    }
                },
                {
                    "nextCommand", new eevee.config {
                        displayName = "nextCommand",
                        KEYBOARD_code = (int)KeyCode.UpArrow,
                        CONTROLLER_name = "Left Stick Up"
                    }
                },
                {
                    "lastCommand", new eevee.config {
                        displayName = "lastCommand",
                        KEYBOARD_code = (int)KeyCode.DownArrow,
                        CONTROLLER_name = "Left Stick Down"
                    }
                }, // noclip controls
                {
                    "noClipUp", new eevee.config {
                        displayName = "noClipUp",
                        KEYBOARD_code = (int)KeyCode.Space,
                        CONTROLLER_name = ""
                    }
                },
                {
                    "noClipDown", new eevee.config {
                        displayName = "noClipDown",
                        KEYBOARD_code = (int)KeyCode.LeftControl,
                        CONTROLLER_name = ""
                    }
                },
                {
                    "noClipSpeed", new eevee.config {
                        displayName = "noClipSpeed",
                        KEYBOARD_code = (int)KeyCode.LeftShift,
                        CONTROLLER_name = ""
                    }
                }
            };
    }

    public static class math {
        public static float hyp(Vector2 input) {
            return Mathf.Sqrt(Mathf.Pow(input.x, 2) + Mathf.Pow(input.y, 2));
        }
    }
}