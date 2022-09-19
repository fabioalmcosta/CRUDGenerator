using System.Text.RegularExpressions;

public static class SagaTemplateGenerator
{
    public static string WriteSagaClass(string featureName, string moduleName, string _actionsTypes, string _pathImport)
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

        var nomeFuncao = char.ToUpper(moduleName[0]) + moduleName.Substring(1);

        var stringFile = @"import { takeEvery, call, put } from 'redux-saga/effects';
import formActions from '@common/store/form/form.actions';
import api from '../service/" + moduleName + @".service';
import " + moduleName + @"Actions from './" + moduleName + @".actions';
import * as types from './" + moduleName + @".actionTypes';

export default workSaga;

function* workSaga() {
  yield takeEvery(types." + _actionsTypes + @"_GET, getById);
  yield takeEvery(types." + _actionsTypes + @"_DELETE, remove);
  yield takeEvery(types." + _actionsTypes + @"_PUT, update);
  yield takeEvery(types." + _actionsTypes + @"_POST, save);
}

function* getById(action) {
  const { id } = action.payload;

  try {
    const result = yield call(api.getById, id);
    yield put(" + moduleName + @"Actions.set" + nomeFuncao + @"(result.data));
  } catch (error) {
    yield put(formActions.redirect('" + _pathImport + @"'));
  }
}

function* save(action) {
    const data = action.payload.data;

    yield call(api.save, data);
    yield put(formActions.inserted());
    yield put(formActions.reload());
}

function* update(action) {
    const { payload } = action;
    const { id, data } = payload;
    
    yield call(api.update, id, data);
    yield put(formActions.updated());
    yield put(formActions.redirect('" + _pathImport + @"'));
    
}

function* remove(action) {
    const { payload } = action;

    yield call(api.remove, payload.id);
    yield put(formActions.deleted());
    yield put(formActions.gridReload());
}";

        return stringFile;

    }
}
