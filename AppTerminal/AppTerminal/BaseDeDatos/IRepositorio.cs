using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTerminal.BaseDeDatos
{
    interface IRepositorio<TEntity> where TEntity : class
    {

        /// <summary>
        /// Agrega la entidad
        /// </summary>
        /// <param name="pEntity">Entidad</param>
        void Add(TEntity pEntity);

        /// <summary>
        /// Elimina una entidad
        /// </summary>
        /// <param name="pEntity">Entidad</param>
        void Remove(TEntity pEntity);

        /// <summary>
        /// Obtiene la entidad por Id
        /// </summary>
        /// <param name="pId">Identificador de la entidad</param>
        /// <returns>Entidad</returns>
        TEntity Get(int pId);

        /// <summary>
        /// Obtiene todas las entidades
        /// </summary>
        /// <returns>Coleccion de entidades</returns>
        IEnumerable<TEntity> GetAll();

    }
}
