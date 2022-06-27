using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace BirlesikOdeme.Business
{
    public class MapperBL
    {
        MapperConfiguration mapperConfig = null;

        public MapperBL(MapperConfiguration mapperConfig)
        {
            this.mapperConfig = mapperConfig;
        } 
              
        public T Map<T>(params object[] sources)
            where T : class
        {
            if (!sources.Any())
            {
                return default(T);
            }

            var initialSource = sources[0];
            var mappingResult = Map<T>(initialSource);
            // Now map the remaining source objects
            if (sources.Count() > 1)
            {
                Map(mappingResult, sources.Skip(1).ToArray());
            }

            return mappingResult;
        }

        public void Map(object destination, params object[] sources)
        {
            var mapper = new Mapper(mapperConfig);
            if (!sources.Any())
            {
                return;
            }

            var destinationType = destination.GetType();
            foreach (var source in sources)
            {
                var sourceType = source.GetType();
                mapper.Map(source, destination, sourceType, destinationType);
            }
        }

        public T Map<T>(object source)
            where T : class
        {
            var mapper = new Mapper(mapperConfig);
            var destinationType = typeof(T);
            var sourceType = source.GetType();
            var mappingResult = mapper.Map(source, sourceType, destinationType);
            return mappingResult as T;
        }
    }
}