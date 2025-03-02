using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string nombre="";
    public int genero;
    public int cuerpo;
    public int cabello;
    public int cara;
    public int pantalon;
    public int sombrero;
    public int ropa;
    public string email = "";
    public Texture2D foto = null;
    public string amigos = "";
    public string idFacebook = "";
    public string idUser = "";

    public void SetPlayer(int _genero, int _cuerpo, int _cara, int _cabello, int _pantalon, int _ropa, int _sombrero, string _nombre, bool isBoss = false)
    {
        nombre      = _nombre;
        genero      = _genero;
        cuerpo      = _cuerpo;
        cabello     = _cabello;
        cara        = _cara;
        pantalon    = _pantalon;
        sombrero    = _sombrero;
        ropa        = _ropa;
    }

}
