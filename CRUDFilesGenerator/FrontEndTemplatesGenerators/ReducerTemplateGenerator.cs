using System.Text.RegularExpressions;

public static class ReducerTemplateGenerator
{
    public static string WriteReducerClass(string featureName, string moduleName, string _actionsTypes)
    {

        string[] split = Regex.Split(moduleName, @"(?<!^)(?=[A-Z])");
        var typeModuleName = "";
        foreach (var item in split)
        {
            if (typeModuleName.Length == 0)
            {
                typeModuleName = item.ToUpper();
            }
            else
            {
                typeModuleName = typeModuleName + "_" + item.ToUpper();
            }
        }

        var stringFile = @"import * as commonActionType from '@common/store/common/common.actionsType';
import store from '@common/store/store';
import Immutable from 'seamless-immutable';
import * as types from './" + moduleName + @".actionTypes'
import ReducerActionType from '@/common/types/reducer.types';

const initialState = Immutable({
  Id: undefined,
});

const reduce = (state = initialState, action: ReducerActionType = {
  type: '',
  payload: undefined,
}) => {
  const payload = action.payload || {};
  switch (action.type) {
    case types." + _actionsTypes + @"_SET:
        return state.merge({ ...payload.data });
    case types." + _actionsTypes + @"_RESET:
        return initialState;
    case commonActionType.RESET:
        return initialState;
    default:
        return state;
  }
};

store.registerDynamicModule('" + featureName + "." + moduleName + "', reduce);";

        return stringFile;

    }
}
