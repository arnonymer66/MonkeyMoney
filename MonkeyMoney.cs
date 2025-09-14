using MelonLoader;
using BTD_Mod_Helper;
using UnityEngine;
using System;

[assembly: MelonInfo(typeof(MonkeyMoney.MonkeyMoney), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace MonkeyMoney
{
    public class MonkeyMoney : BloonsTD6Mod
    {
        private bool isMenuOpen = false;  // Flag, um das Menü zu toggeln
        private string input = "";        // Eingabewert, der durch den Benutzer eingegeben wird
        private int moneyAmount = 0;      // Der Betrag an Monkey Money, der hinzugefügt werden soll

        public override void OnApplicationStart()
        {
            ModHelper.Msg<MonkeyMoney>("MonkeyMoney Mod loaded!");
        }

        public override void OnUpdate()
        {
            // Überprüfen, ob die "E"-Taste gedrückt wurde, um das Menü zu toggeln
            if (Input.GetKeyDown(KeyCode.E))
            {
                isMenuOpen = !isMenuOpen;
                input = "";  // Zurücksetzen der Eingabe, wenn das Menü geschlossen wird
            }

            // Wenn das Menü geöffnet ist, zeichne das Eingabefeld und die Buttons
            if (isMenuOpen)
            {
                ShowMenu();
            }
        }

        private void ShowMenu()
        {
            // Position des Menüs auf dem Bildschirm
            var screenPos = new Vector2(100, 100);

            // Menü Hintergrund zeichnen
            DrawRect(screenPos, new Vector2(300, 200), new Color(0, 0, 0, 0.7f));  // Dunkler Hintergrund

            // Text für Eingabeaufforderung und aktuelle Eingabe anzeigen
            DrawText(screenPos + new Vector2(10, 10), "Geben Sie eine Zahl von 0-9 ein:", 20, Color.white);
            DrawText(screenPos + new Vector2(10, 40), "Eingabe: " + input, 20, Color.yellow);

            // Zeige den aktuellen Betrag, der hinzugefügt wird, wenn Enter gedrückt wird
            DrawText(screenPos + new Vector2(10, 70), "Aktueller Betrag: " + moneyAmount, 20, Color.green);
            DrawText(screenPos + new Vector2(10, 100), "Drücken Sie Enter, um hinzuzufügen", 20, Color.white);
        }

        private void DrawRect(Vector2 position, Vector2 size, Color color)
        {
            // Zeichnet ein Rechteck für das Menü
            var rect = new Rect(position.x, position.y, size.x, size.y);
            var texture = new Texture2D(1, 1);
            texture.SetPixel(0, 0, color);
            texture.Apply();
            GUI.DrawTexture(rect, texture);
        }

        private void DrawText(Vector2 position, string text, int fontSize, Color color)
        {
            // Zeichnet Text auf dem Bildschirm
            GUI.skin.label.fontSize = fontSize;
            GUI.skin.label.normal.textColor = color;
            GUI.Label(new Rect(position.x, position.y, 200, 50), text);
        }

        public override void OnGUI()
        {
            // Wenn das Menü geöffnet ist, erfassen wir Tasteneingaben
            if (isMenuOpen)
            {
                // Tasteneingabe von 0 bis 9
                for (int i = 0; i <= 9; i++)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha0 + i))
                    {
                        input += i.ToString();
                    }
                }

                // Wenn Enter gedrückt wird, fügen wir das Monkey Money hinzu
                if (Input.GetKeyDown(KeyCode.Return) && !string.IsNullOrEmpty(input))
                {
                    if (int.TryParse(input, out moneyAmount))
                    {
                        // Logik, um den Monkey Money-Betrag hinzuzufügen (dies könnte angepasst werden, um tatsächlich das Spiel zu beeinflussen)
                        ModHelper.Msg<MonkeyMoney>($"Monkey Money hinzugefügt: {moneyAmount}");
                        input = "";  // Eingabe zurücksetzen nach Bestätigung
                    }
                    else
                    {
                        ModHelper.Msg<MonkeyMoney>("Ungültige Eingabe! Bitte geben Sie eine Zahl ein.");
                    }
                }
            }
        }
    }
}
