namespace BicycleRent.Domain.Interfaces;
public interface IRepository<TEntity, TKey>
{
    /// <summary>
    /// Returns all elements of a collection
    /// </summary>
    /// <returns></returns>
    public IEnumerable<TEntity> GetAll();

    /// <summary>
    /// Returns an element by id
    /// </summary>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    public TEntity? GetById(TKey id);

    /// <summary>
    /// Delete an element from a collection by id
    /// </summary>
    /// <param name="id"> object's id</param>
    /// <returns></returns>
    public bool Delete(TKey id);

    /// <summary>
    /// Adds an element to a collection
    /// </summary>
    /// <param name="entity">object</param>
    public void Add(TEntity entity);

    /// <summary>
    /// Update an element of a collection by id
    /// </summary>
    /// <param name="entity">object</param>
    /// <param name="id">object's id</param>
    /// <returns></returns>
    public bool Update(TEntity entity, TKey id);
}