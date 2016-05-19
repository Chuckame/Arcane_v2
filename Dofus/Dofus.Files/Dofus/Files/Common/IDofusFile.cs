using System.IO;
using Dofus.IO;

namespace Dofus.IO
{
    /// <summary>
    /// Interface représentant un fichier dofus.
    /// </summary>
    public interface IDofusFile
    {
        /// <summary>
        /// Obtient le type du fichier en lecture.
        /// </summary>
        DofusFileTypeEnum DofusFileType { get; }

        /// <summary>
        /// Charche le fichier à l'emplacement spécifié et le déserialise dans l'instance courante si possible.
        /// </summary>
        /// <param name="path">Le chemin d'accès du fichier.</param>
        /// <exception cref="FileNotFoundException">Si le fichier n'existe pas.</exception>
        void Load(string path);

        /// <summary>
        /// Déserialise des données brutes dans l'instance courante si possible.
        /// </summary>
        /// <param name="bytes">Le tableau d'octets à déserialiser.</param>
        void FromBytes(byte[] bytes);

        /// <summary>
        /// Déserialise le flux dans l'instance courante si possible.
        /// </summary>
        /// <param name="reader">Le flux à déserialiser.</param>
        void FromRaw(IDataReader reader);

        /// <summary>
        /// Sérialise l'instance courante dans le fichier spécifié.
        /// </summary>
        /// <param name="path">Le chemin d'accès du fichier.</param>
        /// <param name="override"><code>true</code> pour remplacer le fichier s'il existe, <code>false</code> pour ne pas le remplacer.</param>
        void Save(string path, bool @override = false);

        /// <summary>
        /// Sérialise l'instance courante dans un tableau d'octets.
        /// </summary>
        /// <returns></returns>
        byte[] ToBytes();

        /// <summary>
        /// Sérialise l'instance courante dans le flux spécifié.
        /// </summary>
        /// <param name="writer">Le flux où l'instance sera sérialisée.</param>
        void ToRaw(IDataWriter writer);
    }
}
