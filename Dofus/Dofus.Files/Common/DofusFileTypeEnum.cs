namespace Dofus.IO
{
    public enum DofusFileTypeEnum
    {
        /// <summary>
        /// Fichier de localisation (.d2i)
        /// </summary>
        Localization,
        /// <summary>
        /// Fichier contenant des objets (.d2o)
        /// </summary>
        GameData,
        /// <summary>
        /// Fichier de localisation (.ele)
        /// </summary>
        MapElements,
        /// <summary>
        /// Fichier de carte (.dlm) contenu généralement dans les fichiers conteneur.
        /// </summary>
        Map,
        /// <summary>
        /// Fichier conteneur (.d2p)
        /// </summary>
        Container,
        /// <summary>
        /// Fichier flash (.swl)
        /// </summary>
        Flash
    }
}
