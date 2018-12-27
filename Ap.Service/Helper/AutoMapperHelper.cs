using AutoMapper;
using System;
using System.Collections.Generic;

namespace AP.Service.Helper
{
    public static class AutoMapperHelper
    {
        public static Paste Mapper<Copy, Paste>(Copy instance)
        {
            try
            {
                #region automapper
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Copy, Paste>();
                });

                var mapper = config.CreateMapper();

                Paste result = mapper.Map<Copy, Paste>(instance);
                #endregion

                return result;
            }
            catch
            {
                return default(Paste);
            }
        }

        public static IEnumerable<Paste> Mapper<Copy, Paste>(IEnumerable<Copy> instance)
        {
            try
            {
                #region automapper
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Copy, Paste>();
                });

                var mapper = config.CreateMapper();

                IEnumerable<Paste> result = mapper.Map<IEnumerable<Copy>, IEnumerable<Paste>>(instance);
                #endregion

                return result;
            }
            catch
            {
                return default(IEnumerable<Paste>);
            }
        }
    }
}
