public static class SearchTemplateGenerator
{
    public static string WriteSearchClass( string moduleName)
    {
        var nomeDaClasse = char.ToUpper(moduleName[0]) + moduleName.Substring(1);

        var stringFile = @"import React, { FC } from 'react';
import Grid" + nomeDaClasse + @" from '../components/" + moduleName + @".grid';
import FloatingButton from '@/components/floatingButton/FloatingButton';

const " + nomeDaClasse + @"Search: FC = () => {
  return (
    <>
      <FloatingButton />
      <Grid" + nomeDaClasse + @" />
    </>
  );
};

export default "+ nomeDaClasse + "Search;";

        return stringFile;

    }
}
